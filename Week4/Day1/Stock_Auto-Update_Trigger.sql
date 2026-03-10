CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY
        
        -- Check if stock is sufficient
        IF EXISTS (
            SELECT 1
            FROM stocks s
            JOIN inserted i
                ON s.product_id = i.product_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            THROW 50001, 'Insufficient stock. Order cannot be processed.', 1;
        END

        -- Reduce stock quantity
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i
            ON s.product_id = i.product_id;

    END TRY

    BEGIN CATCH
        
        -- Rollback transaction if error occurs
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();

        RAISERROR (@ErrorMessage,16,1);

    END CATCH
END;

INSERT INTO order_items(order_id, item_id, product_id, quantity, list_price, discount)
VALUES (1,1,2,2,500,0.05);

INSERT INTO order_items(order_id, item_id, product_id, quantity, list_price, discount)
VALUES (1,2,2,5000,500,0.05);

SELECT *
FROM stocks
WHERE product_id = 2;

