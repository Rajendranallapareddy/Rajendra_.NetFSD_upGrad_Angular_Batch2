// Selecting Elements
const taskInput = document.getElementById("taskInput");
const addTaskBtn = document.getElementById("addTaskBtn");
const taskList = document.getElementById("taskList");

// Function to create new task element
function createTaskElement(taskText) {
    const li = document.createElement("li");

    li.innerHTML = `
        <span class="task-text">${taskText}</span>
        <button class="delete-btn">Delete</button>
    `;

    return li;
}

// Function to add task
function addTask() {
    const taskText = taskInput.value.trim();

    if (taskText === "") {
        alert("Please enter a task!");
        return;
    }

    const taskElement = createTaskElement(taskText);
    taskList.appendChild(taskElement);

    taskInput.value = "";
}

// Event Listener for Add Button
addTaskBtn.addEventListener("click", addTask);

// Event Delegation for Complete & Delete
taskList.addEventListener("click", function (event) {

    // Delete Task
    if (event.target.classList.contains("delete-btn")) {
        event.target.parentElement.remove();
    }

    // Mark Complete
    if (event.target.classList.contains("task-text")) {
        event.target.classList.toggle("completed");
    }

});