import {
    addTaskCallback,
    listTasksCallback,
    addTaskPromise,
    listTasksPromise,
    addTask,
    deleteTask,
    listTasks
} from "./taskManager.js";

// ===============================
// 1️⃣ Callback Example
// ===============================

addTaskCallback("Learn JavaScript", (message) => {
    console.log(`Callback: ${message}`);

    listTasksCallback((tasks) => {
        console.log(`Callback Tasks: ${tasks.join(", ")}`);
    });
});

// ===============================
// 2️⃣ Promise Example
// ===============================

addTaskPromise("Learn Promises")
    .then(message => {
        console.log(`Promise: ${message}`);
        return listTasksPromise();
    })
    .then(tasks => {
        console.log(`Promise Tasks: ${tasks.join(", ")}`);
    });

// ===============================
// 3️⃣ Async/Await Example
// ===============================

const runAsyncVersion = async () => {
    try {
        const addMsg = await addTask("Master Async/Await");
        console.log(`Async: ${addMsg}`);

        const currentTasks = await listTasks();
        console.log(`Async Tasks: ${currentTasks.join(", ")}`);

        const deleteMsg = await deleteTask("Learn JavaScript");
        console.log(`Async: ${deleteMsg}`);

        const updatedTasks = await listTasks();
        console.log(`Updated Tasks: ${updatedTasks.join(", ")}`);

    } catch (error) {
        console.error("Error:", error.message);
    }
};

runAsyncVersion();