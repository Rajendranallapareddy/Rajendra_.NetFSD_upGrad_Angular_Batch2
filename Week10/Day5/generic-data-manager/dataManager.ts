// 1. Generic Function
function getFirstElement<T>(items: T[]): T {
    return items[0];
}

// 2. Generic Interface
interface Repository<T> {
    add(item: T): void;
    getAll(): T[];
}

// 3. Generic Class
class DataManager<T> implements Repository<T> {
    private items: T[] = [];

    add(item: T): void {
        this.items.push(item);
    }

    getAll(): T[] {
        return this.items;
    }
}

// 4. Models
interface User {
    id: number;
    name: string;
}

interface Product {
    id: number;
    title: string;
}

// 5. Use Case

// User Manager
const userManager = new DataManager<User>();
userManager.add({ id: 1, name: "Kartik" });
userManager.add({ id: 2, name: "Rahul" });

// Product Manager
const productManager = new DataManager<Product>();
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mobile" });

// 6. Testing

console.log("Users:", userManager.getAll());
console.log("Products:", productManager.getAll());

const numbers = [10, 20, 30];
console.log("First Number:", getFirstElement(numbers));

const users = userManager.getAll();
console.log("First User:", getFirstElement(users));