CREATE DATABASE EcommDb;
GO

USE EcommDb;
GO

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100)
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(150),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(100),
    last_name VARCHAR(100),
    phone VARCHAR(20),
    email VARCHAR(100),
    street VARCHAR(200),
    city VARCHAR(100),
    state VARCHAR(50),
    zip_code VARCHAR(10)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(150),
    phone VARCHAR(20),
    email VARCHAR(100),
    street VARCHAR(200),
    city VARCHAR(100),
    state VARCHAR(50),
    zip_code VARCHAR(10)
);

INSERT INTO categories VALUES
(1,'SUV'),
(2,'Sedan'),
(3,'Truck'),
(4,'Hatchback'),
(5,'Electric');

INSERT INTO brands VALUES
(1,'Toyota'),
(2,'Honda'),
(3,'Ford'),
(4,'Tesla'),
(5,'Hyundai');

INSERT INTO products VALUES
(1,'Toyota RAV4',1,1,2023,30000),
(2,'Honda Civic',2,2,2023,25000),
(3,'Ford F150',3,3,2023,40000),
(4,'Tesla Model 3',4,5,2024,45000),
(5,'Hyundai i20',5,4,2023,20000);

INSERT INTO customers VALUES
(1,'John','Smith','9876543210','john@email.com','Street 1','New York','NY','10001'),
(2,'Emma','Watson','9876543211','emma@email.com','Street 2','Chicago','IL','60601'),
(3,'David','Brown','9876543212','david@email.com','Street 3','New York','NY','10002'),
(4,'Sophia','Lee','9876543213','sophia@email.com','Street 4','Dallas','TX','75001'),
(5,'Michael','Clark','9876543214','michael@email.com','Street 5','Chicago','IL','60602');

INSERT INTO stores VALUES
(1,'Auto Hub','9001111111','hub@email.com','Street A','New York','NY','10001'),
(2,'Car World','9002222222','world@email.com','Street B','Chicago','IL','60601'),
(3,'Drive Zone','9003333333','drive@email.com','Street C','Dallas','TX','75001'),
(4,'Motor Point','9004444444','motor@email.com','Street D','Houston','TX','77001'),
(5,'Speed Motors','9005555555','speed@email.com','Street E','Phoenix','AZ','85001');

SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

SELECT *
FROM customers
WHERE city = 'New York';

SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id = p.category_id
GROUP BY c.category_name;

