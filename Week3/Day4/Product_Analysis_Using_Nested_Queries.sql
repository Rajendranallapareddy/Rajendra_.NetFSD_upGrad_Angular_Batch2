SELECT 
    CONCAT(product_name, ' (', model_year, ')') AS product_details,
    product_name,
    model_year,
    list_price,
    list_price - (
        SELECT AVG(p2.list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
    ) AS price_difference
FROM products p1
WHERE list_price > (
    SELECT AVG(p3.list_price)
    FROM products p3
    WHERE p3.category_id = p1.category_id
);