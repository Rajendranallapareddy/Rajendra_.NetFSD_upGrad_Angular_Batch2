CREATE TRIGGER trg_ValidateOrderCompletion
ON orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY
        
        -- Check if any completed order has NULL shipped_date
        IF EXISTS (
            SELECT 1
            FROM inserted
            WHERE order_status = 4
            AND shipped_date IS NULL
        )
        BEGIN
            THROW 50002, 'Order cannot be marked as Completed because shipped_date is NULL.', 1;
        END

    END TRY

    BEGIN CATCH

        -- Rollback the transaction
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR (@ErrorMessage,16,1);

    END CATCH
END;

UPDATE orders
SET shipped_date = '2024-05-20',
    order_status = 4
WHERE order_id = 1;

SELECT *
FROM orders
WHERE order_id = 1;