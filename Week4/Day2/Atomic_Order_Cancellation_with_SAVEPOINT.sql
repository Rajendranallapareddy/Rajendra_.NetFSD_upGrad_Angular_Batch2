BEGIN TRY

BEGIN TRANSACTION

DECLARE @order_id INT
SET @order_id = 101   -- Order to cancel

-- SAVEPOINT before restoring stock
SAVE TRANSACTION RestoreStockPoint

-- Restore stock quantities
UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM stocks s
JOIN order_items oi
ON s.product_id = oi.product_id
JOIN orders o
ON oi.order_id = o.order_id
AND s.store_id = o.store_id
WHERE oi.order_id = @order_id

-- Check if stock restoration succeeded
IF @@ROWCOUNT = 0
BEGIN
    RAISERROR('Stock restoration failed. Rolling back to SAVEPOINT.',16,1)
    ROLLBACK TRANSACTION RestoreStockPoint
END

-- Update order status to Rejected
UPDATE orders
SET order_status = 3
WHERE order_id = @order_id

-- Commit transaction
COMMIT TRANSACTION

PRINT 'Order cancelled successfully and stock restored.'

END TRY

BEGIN CATCH

-- Rollback entire transaction if error occurs
ROLLBACK TRANSACTION

PRINT 'Error occurred during order cancellation.'
PRINT ERROR_MESSAGE()

END CATCH

SELECT 
order_id,
order_status
FROM orders
WHERE order_id = 101;

SELECT *
FROM stocks
WHERE product_id IN
(
    SELECT product_id
    FROM order_items
    WHERE order_id = 101
);