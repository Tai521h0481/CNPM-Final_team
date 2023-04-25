create database MobilePhone
go
use MobilePhone
go
CREATE TABLE WarehouseReceipt
(
  ReceiptID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  TotalWarehouseQuantity INT NOT NULL,
  TotalWarehousePrice INT NOT NULL,
  CreatedDate DATE NOT NULL
);

CREATE TABLE Product
(
  ProductID VARCHAR(10) NOT NULL PRIMARY KEY,
  ProductName NVARCHAR(50) NOT NULL,
  ProductPrice INT NOT NULL,
  ProductQuantity INT NOT NULL
);

CREATE TABLE Agent
(
  AgentID VARCHAR(10) NOT NULL PRIMARY KEY,
  AgentName NVARCHAR(50) NOT NULL,
  AgentAccount NVARCHAR(50) NOT NULL,
  AgentPassword NVARCHAR(50) NOT NULL,
  AgentAddress NVARCHAR(100),
  AgentPhoneNumber NVARCHAR(20)
);

CREATE TABLE OrderReceipt
(
  OrderID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  TotalOrderPrice INT NOT NULL,
  TotalOrderQuantity INT NOT NULL,
  OrderedDate DATE NOT NULL,
  Status NVARCHAR(50) NOT NULL,
  AgentID VARCHAR(10) NOT NULL,
  PaymentMethod NVARCHAR(50),
  PaymentStatus NVARCHAR(50),
  OrderStatus NVARCHAR(50),
  CONSTRAINT FkOrderReceipt_AgentID FOREIGN KEY (AgentID) REFERENCES Agent(AgentID) 
);

CREATE TABLE IncludeOrderProducts
(
  TotalProductQuantity INT NOT NULL,
  TotalProductPrice INT NOT NULL,
  OrderID INT NOT NULL,
  ProductID VARCHAR(10) NOT NULL,
  CONSTRAINT PkIncludeOrderProducts_OrderID_ProductID PRIMARY KEY (OrderID, ProductID),
  CONSTRAINT FkIncludeOrderProducts_OrderID FOREIGN KEY (OrderID) REFERENCES OrderReceipt(OrderID),
  CONSTRAINT FkIncludeOrderProducts_ProductID FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE IncludeImportedProducts
(
  TotalProductQuantity INT NOT NULL,
  TotalProductPrice INT NOT NULL,
  ReceiptID INT NOT NULL,
  ProductID VARCHAR(10) NOT NULL,
  CONSTRAINT PkIncludeImportedProducts PRIMARY KEY (ReceiptID, ProductID),
  CONSTRAINT FkIncludeImportedProducts_ReceiptID FOREIGN KEY (ReceiptID) REFERENCES WarehouseReceipt(ReceiptID),
  CONSTRAINT FkIncludeImportedProducts_ProductID FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE Distributor
(
  DistributorID VARCHAR(10) NOT NULL PRIMARY KEY,
  DistributorAccount NVARCHAR(50) NOT NULL,
  DistributorPassword NVARCHAR(50) NOT NULL
);

INSERT INTO Product (ProductID, ProductName, ProductPrice, ProductQuantity)
VALUES ('P001', 'iPhone 12', 1000, 100),
       ('P002', 'Samsung Galaxy S21', 900, 100),
       ('P003', 'Google Pixel 5', 800, 100),
       ('P004', 'OnePlus 9', 700, 100),
       ('P005', 'Xiaomi Mi 11', 600, 100),
       ('P006', 'Oppo Find X3', 500, 100),
       ('P007', 'Vivo X60', 400, 100),
       ('P008', 'Realme GT', 300, 100),
       ('P009', 'Nokia X20', 200, 100),
       ('P010', 'Motorola Moto G30', 100, 100);

-- Insert data into the Distributor table to represent a distributor
INSERT INTO Distributor (DistributorID, DistributorAccount, DistributorPassword)
VALUES ('D001', 'distributor1', 'password1');

-- Insert data into the Agent table to represent a reseller/agent
INSERT INTO Agent (AgentID, AgentName, AgentAccount, AgentPassword, AgentAddress, AgentPhoneNumber)
VALUES ('A001', 'Agent1', 'agent1', 'password1', '123 Main Street', '555-1234'),
('A002', 'Agent2', 'agent2', 'password2', 'Tan Phong', '999-8888');

-- Insert data into the WarehouseReceipt table to represent an import of goods by the distributor
INSERT INTO WarehouseReceipt (TotalWarehouseQuantity, TotalWarehousePrice, CreatedDate)
VALUES 
    (1000, 5500, '2023-01-01'),
    (2000, 6000, '2023-02-01'),
    (3000, 6500, '2023-03-01'),
    (4000, 7000, '2023-04-01'),
    (5000, 7500, '2023-05-01'),
    (6000, 8000, '2023-06-01'),
    (7000, 8500, '2023-07-01'),
    (8000, 9000, '2023-08-01'),
    (9000, 9500, '2023-09-01'),
    (10000, 10000, '2023-10-01'),
    (11000, 10500, '2023-11-01'),
    (12000, 11000, '2023-12-01');

-- Insert data into the IncludeImportedProducts table to specify the quantity and price of each product that was imported
INSERT INTO IncludeImportedProducts (TotalProductQuantity, TotalProductPrice, ReceiptID, ProductID)
VALUES (100, 1000, 1, 'P001'),
       (100, 900, 1, 'P002'),
       (100, 800, 1, 'P003'),
       (100, 700, 1, 'P004'),
       (100, 600, 1,'P005'),
       (100, 500 ,1,'P006'),
       (100 ,400 ,1,'P007'),
       (100 ,300 ,1,'P008'),
       (100 ,200 ,1,'P009'),
       (100 ,100 ,1,'P010');



DECLARE @month AS INT = 1;
WHILE @month <= 12
BEGIN
    INSERT INTO OrderReceipt (TotalOrderPrice, TotalOrderQuantity, OrderedDate, Status, AgentID)
    VALUES 
        (10000 * @month, 1000 * @month, DATEFROMPARTS(2023, @month, 1), 'Completed', 'A001'),
        (20000 * @month, 2000 * @month, DATEFROMPARTS(2023, @month, 15), 'Completed', 'A001');
    SET @month = @month + 1;
END

-- Insert data into the IncludeOrderProducts table
INSERT INTO IncludeOrderProducts (TotalProductQuantity, TotalProductPrice, OrderID, ProductID)
SELECT 
    TotalOrderQuantity / 15 AS TotalProductQuantity,
    TotalOrderPrice / 15 AS TotalProductPrice,
    OrderID,
    'P' + RIGHT('00' + CAST(ROW_NUMBER() OVER(PARTITION BY OrderID ORDER BY ProductID) AS NVARCHAR(3)), 3) AS ProductID
FROM 
    OrderReceipt
CROSS JOIN 
    Product;