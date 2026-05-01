"use strict";
class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    getSalary() {
        return this.salary;
    }
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Salary must be greater than 0");
        }
    }
    displayDetails() {
        console.log(`ID: ${this.id}`);
        console.log(`Name: ${this.name}`);
        console.log(`Salary: ${this.salary}`);
    }
}
class Manager extends Employee {
    teamSize;
    constructor(id, name, salary, teamSize) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }
    displayDetails() {
        super.displayDetails();
        console.log(`Team Size: ${this.teamSize}`);
    }
}
const emp1 = new Employee(101, "Kartik", 50000);
const mgr1 = new Manager(201, "Rahul", 80000, 5);
console.log("---- Employee Details ----");
emp1.displayDetails();
console.log("\n---- Manager Details ----");
mgr1.displayDetails();
emp1.setSalary(55000);
console.log("\nUpdated Salary:", emp1.getSalary());
