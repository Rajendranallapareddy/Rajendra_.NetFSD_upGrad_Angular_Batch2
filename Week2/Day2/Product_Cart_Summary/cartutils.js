export const calculateTotal = (products) =>
    products.reduce(
        (total, product) => total + product.price * product.quantity,
        0
    );

export const generateInvoice = (products) => {

    const itemLines = products
        .map(
            ({ name, price, quantity }) =>
                `${name} - ₹${price} x ${quantity} = ₹${price * quantity}`
        )
        .join("\n");

    const total = calculateTotal(products);

    return `
==============================
        INVOICE SUMMARY
==============================
${itemLines}
------------------------------
Total Amount: ₹${total}
==============================
`;
};