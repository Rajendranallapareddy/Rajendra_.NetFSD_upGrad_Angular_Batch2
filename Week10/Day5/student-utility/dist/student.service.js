"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.getGrade = getGrade;
exports.getTopper = getTopper;
const constants_1 = require("./constants");
function getGrade(marks) {
    if (marks >= 80)
        return "A";
    if (marks >= 60)
        return "B";
    if (marks >= constants_1.PASS_MARKS)
        return "C";
    return "Fail";
}
function getTopper(students) {
    return students.reduce((topper, curr) => curr.marks > topper.marks ? curr : topper);
}
