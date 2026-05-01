"use strict";
// Required parameter
function getWelcomeMessage(name) {
    return `Welcome, ${name}!`;
}
// Optional parameter
function getUserInfo(name, age) {
    if (age !== undefined) {
        return `User: ${name}, Age: ${age}`;
    }
    return `User: ${name}`;
}
// Default parameter
function getSubscriptionStatus(name, isSubscribed = false) {
    return isSubscribed
        ? `${name} is subscribed`
        : `${name} is not subscribed`;
}
// Boolean return type
function isEligibleForPremium(age) {
    return age >= 18;
}
// Arrow function
const getAccountStatus = (name) => {
    return `Account of ${name} is active`;
};
// Lexical this
const NotificationService = {
    appName: "MyAngularApp",
    sendNotification: (message) => {
        return `[${NotificationService.appName}] ${message}`;
    }
};
// Execution
console.log(getWelcomeMessage("Kartik"));
console.log(getUserInfo("Kartik", 22));
console.log(getUserInfo("Kartik"));
console.log(getSubscriptionStatus("Kartik", true));
console.log(getSubscriptionStatus("Kartik"));
console.log(isEligibleForPremium(20));
console.log(getAccountStatus("Kartik"));
console.log(NotificationService.sendNotification("Welcome to the system"));
