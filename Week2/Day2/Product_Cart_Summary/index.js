import { calculateTotal, generateInvoice } from "./cartutils.js";
const cart = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 800, quantity: 2 },
    { name: "Keyboard", price: 1500, quantity: 1 }
];

const totalValue = calculateTotal(cart);
const invoice = generateInvoice(cart);
console.log(invoice);