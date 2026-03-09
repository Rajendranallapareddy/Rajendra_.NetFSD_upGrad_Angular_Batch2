CREATE VIEW vw_ProductDetails
AS
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

CREATE VIEW vw_OrderSummary
AS
SELECT 
    o.order_id,
    CONCAT(c.first_name,' ',c.last_name) AS customer_name,
    s.store_name,
    CONCAT(st.first_name,' ',st.last_name) AS staff_name,
    o.order_date,
    o.order_status
FROM orders o
JOIN customers c
    ON o.customer_id = c.customer_id
JOIN stores s
    ON o.store_id = s.store_id
JOIN staffs st
    ON o.staff_id = st.staff_id;

-- Index on products foreign keys
CREATE INDEX idx_products_brand
ON products(brand_id);

CREATE INDEX idx_products_category
ON products(category_id);

-- Index on orders foreign keys
CREATE INDEX idx_orders_customer
ON orders(customer_id);

CREATE INDEX idx_orders_store
ON orders(store_id);

CREATE INDEX idx_orders_staff
ON orders(staff_id);

-- Index on order_items foreign keys
CREATE INDEX idx_orderitems_order
ON order_items(order_id);

CREATE INDEX idx_orderitems_product
ON order_items(product_id);

-- Index on stocks foreign keys
CREATE INDEX idx_stocks_store
ON stocks(store_id);

CREATE INDEX idx_stocks_product
ON stocks(product_id);

SELECT * FROM vw_ProductDetails;

SELECT * FROM vw_OrderSummary;

SET STATISTICS IO ON;
SET STATISTICS TIME ON;

SELECT *
FROM vw_ProductDetails
WHERE brand_name = 'Toyota';

