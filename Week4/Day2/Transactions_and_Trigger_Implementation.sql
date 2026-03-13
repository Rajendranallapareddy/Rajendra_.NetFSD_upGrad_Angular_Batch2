CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if stock is insufficient
    IF EXISTS (
        SELECT 1
        FROM stocks s
        JOIN inserted i 
        ON s.product_id = i.product_id 
        AND s.store_id = (
            SELECT store_id FROM orders WHERE order_id = i.order_id
        )
        WHERE s.quantity < i.quantity
    )
    BEGIN
        RAISERROR('Insufficient stock available.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce stock quantity
    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN inserted i 
    ON s.product_id = i.product_id
    JOIN orders o
    ON i.order_id = o.order_id
    AND s.store_id = o.store_id;
END;

BEGIN TRY

BEGIN TRANSACTION

-- Insert new order
INSERT INTO orders
(order_id, customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id)
VALUES
(101, 1, 1, GETDATE(), DATEADD(day,7,GETDATE()), NULL, 1, 1)

-- Insert order items
INSERT INTO order_items
(order_id, item_id, product_id, quantity, list_price, discount)
VALUES
(101,1,2,3,500,0.05)

-- Commit transaction
COMMIT TRANSACTION

PRINT 'Order placed successfully.'

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT 'Order failed due to stock issue.'
PRINT ERROR_MESSAGE()

END CATCH

SELECT *
FROM stocks
WHERE product_id = 2;
