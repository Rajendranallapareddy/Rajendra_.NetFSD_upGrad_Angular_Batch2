
-- Create Database
CREATE DATABASE InventoryDB;
GO

USE InventoryDB;
GO

-- Create Products Table
CREATE TABLE Products
(
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);
GO

-- =============================================
-- STORED PROCEDURES
-- =============================================

-- 1. Insert Product
CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products (ProductName, Category, Price)
    VALUES (@ProductName, @Category, @Price);
    
    SELECT SCOPE_IDENTITY() AS NewProductId;
END
GO

-- 2. Get All Products
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT ProductId, ProductName, Category, Price
    FROM Products
    ORDER BY ProductId;
END
GO

-- 3. Update Product
CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Category = @Category,
        Price = @Price
    WHERE ProductId = @ProductId;
    
    RETURN @@ROWCOUNT;
END
GO

-- 4. Delete Product
CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products
    WHERE ProductId = @ProductId;
    
    RETURN @@ROWCOUNT;
END
GO

-- =============================================
-- SAMPLE DATA
-- =============================================

INSERT INTO Products (ProductName, Category, Price)
VALUES 
    ('Laptop Dell XPS', 'Electronics', 85000),
    ('Wireless Mouse', 'Electronics', 799),
    ('Notebook', 'Stationery', 45),
    ('Office Chair', 'Furniture', 5500),
    ('USB Cable', 'Accessories', 199);

GO

-- Verify data
SELECT * FROM Products;
GO