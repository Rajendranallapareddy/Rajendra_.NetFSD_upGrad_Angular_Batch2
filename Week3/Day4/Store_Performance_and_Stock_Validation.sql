SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * oi.list_price) - oi.discount) AS total_revenue
FROM 
    stores s
JOIN orders o 
    ON s.store_id = o.store_id
JOIN order_items oi 
    ON o.order_id = oi.order_id
JOIN products p 
    ON oi.product_id = p.product_id
GROUP BY 
    s.store_name, p.product_name;

SELECT DISTINCT store_id, product_id
FROM orders o
JOIN order_items oi
ON o.order_id = oi.order_id;

SELECT store_id, product_id
FROM stocks
WHERE quantity > 0;

SELECT store_id, product_id
FROM (
    SELECT DISTINCT o.store_id, oi.product_id
    FROM orders o
    JOIN order_items oi
    ON o.order_id = oi.order_id
) AS sold_products

EXCEPT

SELECT store_id, product_id
FROM stocks
WHERE quantity > 0;

SELECT store_id, product_id
FROM (
    SELECT DISTINCT o.store_id, oi.product_id
    FROM orders o
    JOIN order_items oi
    ON o.order_id = oi.order_id
) AS sold_products

INTERSECT

SELECT store_id, product_id
FROM stocks;

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * oi.list_price) - oi.discount) AS total_revenue
FROM stores s
JOIN orders o 
    ON s.store_id = o.store_id
JOIN order_items oi 
    ON o.order_id = oi.order_id
JOIN products p 
    ON oi.product_id = p.product_id
GROUP BY 
    s.store_name, p.product_name;

UPDATE stocks
SET quantity = 0
WHERE product_id IN (
    SELECT p.product_id
    FROM products p
    LEFT JOIN order_items oi
    ON p.product_id = oi.product_id
    WHERE oi.product_id IS NULL
);

