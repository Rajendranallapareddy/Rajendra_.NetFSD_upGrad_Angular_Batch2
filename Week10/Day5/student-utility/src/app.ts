import { Student } from "./student.model";
import { getGrade, getTopper } from "./student.service";
import { formatName, calculateAverage } from "./utils";

const students: Student[] = [
    { id: 1, name: "kartik", marks: 85 },
    { id: 2, name: "rahul", marks: 72 },
    { id: 3, name: "aman", marks: 35 }
];

// Formatted Names
console.log("Formatted Names:");
students.forEach(s => {
    console.log(formatName(s.name));
});

// Grades
console.log("\nGrades:");
students.forEach(s => {
    console.log(`${s.name}: ${getGrade(s.marks)}`);
});

// Average Marks
const avg = calculateAverage(students);
console.log("\nAverage Marks:", avg);

// Topper
const topper = getTopper(students);
console.log("\nTopper:", topper);