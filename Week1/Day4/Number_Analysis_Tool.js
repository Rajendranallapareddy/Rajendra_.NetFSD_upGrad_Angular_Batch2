let number = 7;

let result = (number >= 0) ? "Positive" : "Negative";
console.log("Number is: " + result);

if (number % 2 === 0) {
    console.log("Number is Even");
} else {
    console.log("Number is Odd");
}
console.log("Numbers from 1 to " + number + ":");

for (let i = 1; i <= number; i++) {
    console.log(i);
}
