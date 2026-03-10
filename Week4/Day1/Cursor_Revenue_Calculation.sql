CREATE TABLE #OrderRevenue
(
    order_id INT,
    store_id INT,
    revenue DECIMAL(12,2)
);

BEGIN TRY

BEGIN TRANSACTION

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(12,2)

DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO @order_id, @store_id

WHILE @@FETCH_STATUS = 0
BEGIN

    -- Calculate revenue for the order
    SELECT 
        @revenue = SUM(quantity * list_price * (1 - discount))
    FROM order_items
    WHERE order_id = @order_id

    -- Insert into temp table
    INSERT INTO #OrderRevenue(order_id, store_id, revenue)
    VALUES(@order_id, @store_id, ISNULL(@revenue,0))

    FETCH NEXT FROM order_cursor INTO @order_id, @store_id

END

CLOSE order_cursor
DEALLOCATE order_cursor

COMMIT TRANSACTION

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT 'Error occurred during revenue calculation'
PRINT ERROR_MESSAGE()

END CATCH

SELECT 
    s.store_name,
    SUM(r.revenue) AS total_store_revenue
FROM #OrderRevenue r
JOIN stores s
ON r.store_id = s.store_id
GROUP BY s.store_name
ORDER BY total_store_revenue DESC;

