// Required parameter
function getWelcomeMessage(name: string): string {
    return `Welcome, ${name}!`;
}

// Optional parameter
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return `User: ${name}, Age: ${age}`;
    }
    return `User: ${name}`;
}

// Default parameter
function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
    return isSubscribed
        ? `${name} is subscribed`
        : `${name} is not subscribed`;
}

// Boolean return type
function isEligibleForPremium(age: number): boolean {
    return age >= 18;
}

// Arrow function
const getAccountStatus = (name: string): string => {
    return `Account of ${name} is active`;
};

// Lexical this
const NotificationService = {
    appName: "MyAngularApp",

    sendNotification: (message: string): string => {
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