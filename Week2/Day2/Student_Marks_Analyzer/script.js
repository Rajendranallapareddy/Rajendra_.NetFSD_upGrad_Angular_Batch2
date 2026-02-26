const marks = [78, 85, 90, 67, 88];
const calculateTotal = (arr) =>
    arr.reduce((sum, mark) => sum + mark, 0);
const calculateAverage = (arr) => {
    const total = calculateTotal(arr);
    return total / arr.length;
};
const getResult = (average) =>
    average >= 50 ? "Pass ✅" : "Fail ❌";
const generateReport = (arr) =>
    arr.map((mark, index) =>
        `Subject ${index + 1}: ${mark}`
    ).join("<br>");

const total = calculateTotal(marks);
const average = calculateAverage(marks);
const result = getResult(average);
const report = generateReport(marks);

document.getElementById("output").innerHTML = `
    <h3>Marks Report</h3>
    ${report}
    <br><br>
    <strong>Total Marks:</strong> ${total} <br>
    <strong>Average Marks:</strong> ${average.toFixed(2)} <br>
    <strong>Result:</strong> ${result}
`;