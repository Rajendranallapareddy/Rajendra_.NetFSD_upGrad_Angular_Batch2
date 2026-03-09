CREATE TABLE archived_orders
(
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT,
    staff_id INT
);

INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

SELECT customer_id
FROM customers
WHERE customer_id NOT IN
(
    SELECT customer_id
    FROM orders
    WHERE order_status <> 4
);

SELECT 
order_id,
order_date,
shipped_date,
DATEDIFF(day, order_date, shipped_date) AS processing_delay_days
FROM orders;

SELECT 
order_id,
order_date,
required_date,
shipped_date,
CASE
    WHEN shipped_date > required_date THEN 'Delayed'
    ELSE 'On Time'
END AS order_status_result
FROM orders;

