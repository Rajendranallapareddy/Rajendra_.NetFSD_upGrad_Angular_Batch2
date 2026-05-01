// ==============================
// 1. VARIABLE DECLARATION
// ==============================

// Using const (values that should not change)
const userName: string = "John";
const email: string = "john@example.com";
const isSubscribed: boolean = true;

// Using let (value can change)
let age: number = 25;


// ==============================
// 2. TYPE INFERENCE
// ==============================

// TypeScript will automatically infer types
let country = "India";   // string inferred
let score = 100;         // number inferred


// ==============================
// 3. TEMPLATE LITERALS
// ==============================

let profileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;

console.log("Profile Message:");
console.log(profileMessage);


// ==============================
// 4. OPERATORS
// ==============================

// Increment age
age = age + 1;   // OR age++

console.log("\nUpdated Age:", age);

// Check premium eligibility
let isEligibleForPremium: boolean = (age > 18) && isSubscribed;

console.log("Is Eligible for Premium:", isEligibleForPremium);


// ==============================
// 5. ADDITIONAL OUTPUT
// ==============================

console.log("\n--- User Details ---");
console.log("Name:", userName);
console.log("Age:", age);
console.log("Email:", email);
console.log("Subscribed:", isSubscribed);
console.log("Country (Inferred):", country);
console.log("Score (Inferred):", score);