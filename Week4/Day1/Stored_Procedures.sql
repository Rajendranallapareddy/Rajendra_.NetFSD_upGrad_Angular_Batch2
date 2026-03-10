CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN
    SELECT 
        s.store_name,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
    FROM stores s
    JOIN orders o
        ON s.store_id = o.store_id
    JOIN order_items oi
        ON o.order_id = oi.order_id
    WHERE o.order_status = 4
    GROUP BY s.store_name
    ORDER BY total_sales DESC;
END;

EXEC sp_TotalSalesPerStore;

CREATE PROCEDURE sp_GetOrdersByDateRange
    @start_date DATE,
    @end_date DATE
AS
BEGIN
    SELECT 
        order_id,
        customer_id,
        order_date,
        order_status
    FROM orders
    WHERE order_date BETWEEN @start_date AND @end_date
    ORDER BY order_date;
END;

EXEC sp_GetOrdersByDateRange '2023-01-01','2023-12-31';

CREATE FUNCTION fn_CalculateDiscountPrice
(
    @price DECIMAL(10,2),
    @discount DECIMAL(4,2),
    @quantity INT
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @total DECIMAL(10,2)

    SET @total = @quantity * @price * (1 - ISNULL(@discount,0))

    RETURN @total
END;

CREATE FUNCTION fn_TopSellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(oi.quantity) AS total_sold
    FROM order_items oi
    JOIN products p
        ON oi.product_id = p.product_id
    GROUP BY p.product_name
    ORDER BY total_sold DESC
);

SELECT * FROM fn_TopSellingProducts();

