CREATE DATABASE [YourStoreDB]
GO

USE [YourStoreDB]
GO

CREATE TABLE ProductCategories (
    Id INT IDENTITY(1,1),
    [Name] VARCHAR(100) NOT NULL,
    CreationDate DATETIME DEFAULT GETDATE(),
    Active BIT DEFAULT 1,
    CONSTRAINT PK_ProductCategory_Id PRIMARY KEY(Id)
);

CREATE TABLE Departments (
    [Id] INT IDENTITY(1,1),
    [Name] VARCHAR(100) NOT NULL,
    [CreationDate] DATETIME DEFAULT GETDATE(),
    [EmployeesNumber] INT DEFAULT 0,
    CONSTRAINT PK_Department_Id PRIMARY KEY(Id)
);

CREATE TABLE Clients (
    Id INT IDENTITY(1,1),
    [Name] NVARCHAR(120) NOT NULL,
    Email NVARCHAR(150),
    ContactNumber NVARCHAR(15),
    FirstVisit DATETIME,
    CONSTRAINT PK_Client_Id PRIMARY KEY(Id)
);

-- x x x x x x x x x x x x x x x x x x x x x x x x x 

CREATE TABLE ProductSubCategories (
    Id INT IDENTITY(1,1),
    CategoryId INT NOT NULL,
    [Name] VARCHAR(100) NOT NULL,
    CreationDate DATETIME DEFAULT GETDATE(),
    Active BIT DEFAULT 1,
    CONSTRAINT PK_ProductSubCategorie_Id PRIMARY KEY(Id),
    CONSTRAINT FK_SubCategory_Category FOREIGN KEY (CategoryId) REFERENCES ProductCategories(Id)
);

CREATE TABLE Positions (
    Id INT IDENTITY(1,1),
    DepartmentId INT NOT NULL,
    Title VARCHAR(100) NOT NULL,
    Wage DECIMAL(18, 2),
    CONSTRAINT PK_Position_Id PRIMARY KEY(Id),
    CONSTRAINT FK_Positions_Departments FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

-- x x x x x x x x x x x x x x x x x x x x x x x x x x

CREATE TABLE Employees (
    Id INT IDENTITY(1,1),
    PositionId INT NOT NULL,
    [Name] NVARCHAR(120) NOT NULL,
    Email NVARCHAR(150),
    ContactNumber NVARCHAR(15),
    BirthDate DATE,

    CONSTRAINT PK_Employee_Id PRIMARY KEY(Id),
    CONSTRAINT FK_Employees_Positions FOREIGN KEY (PositionId) REFERENCES Positions(Id)
);

CREATE TABLE Products (
    Id INT IDENTITY(1,1),
    SubCategoryId INT NOT NULL,
    [Name] NVARCHAR(120) NOT NULL,
    [Description] NVARCHAR(400),
    Price DECIMAL(18, 2) NOT NULL,
    ImageUrl NVARCHAR(250),

    CONSTRAINT PK_Product_Id PRIMARY KEY(Id),
    CONSTRAINT FK_Products_SubCategory FOREIGN KEY (SubCategoryId) REFERENCES ProductSubCategories(Id)
);

-- x x x x x x x x x x x x x x x x x x x x x x x x x x x

CREATE TABLE Purchases (
    Id INT IDENTITY(1,1),
    ClientId INT NOT NULL,
    EmployeeId INT NOT NULL,
    NumberProducts INT,
    TotalPrice DECIMAL(12,2),
    [Date] DATETIME DEFAULT GETDATE(),
    CONSTRAINT PK_Purchase_Id PRIMARY KEY(Id),
    CONSTRAINT FK_Purchase_Client FOREIGN KEY (ClientId) REFERENCES Clients(Id),
    CONSTRAINT FK_Purchase_Employee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

CREATE TABLE ProductPurchase (
    PurchaseId INT NOT NULL,
    ProductId INT NOT NULL,
    PRIMARY KEY (PurchaseId, ProductId),
    CONSTRAINT FK_PP_Purchase FOREIGN KEY (PurchaseId) REFERENCES Purchases(Id),
    CONSTRAINT FK_PP_Product FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
GO
