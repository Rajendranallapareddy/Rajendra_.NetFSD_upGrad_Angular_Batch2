-- Customers who placed orders
SELECT 
    CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
    total_order_value,
    CASE 
        WHEN total_order_value > 10000 THEN 'Premium'
        WHEN total_order_value BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS customer_category
FROM customers c
JOIN (
        SELECT 
            o.customer_id,
            SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_order_value
        FROM orders o
        JOIN order_items oi 
            ON o.order_id = oi.order_id
        GROUP BY o.customer_id
     ) AS order_totals
ON c.customer_id = order_totals.customer_id

UNION

-- Customers who have not placed orders
SELECT 
    CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
    0 AS total_order_value,
    'No Orders' AS customer_category
FROM customers c
LEFT JOIN orders o 
    ON c.customer_id = o.customer_id
WHERE o.order_id IS NULL;