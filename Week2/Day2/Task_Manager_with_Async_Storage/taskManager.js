// ===============================
// Task Manager - Callback Version
// ===============================

let tasks = [];

export const addTaskCallback = (task, callback) => {
    setTimeout(() => {
        tasks.push(task);
        callback(`Task "${task}" added successfully.`);
    }, 1000);
};

export const deleteTaskCallback = (task, callback) => {
    setTimeout(() => {
        tasks = tasks.filter(t => t !== task);
        callback(`Task "${task}" deleted successfully.`);
    }, 1000);
};

export const listTasksCallback = (callback) => {
    setTimeout(() => {
        callback(tasks);
    }, 1000);
};

// ===============================
// Task Manager - Promise Version
// ===============================

export const addTaskPromise = (task) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks.push(task);
            resolve(`Task "${task}" added successfully.`);
        }, 1000);
    });
};

export const deleteTaskPromise = (task) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks = tasks.filter(t => t !== task);
            resolve(`Task "${task}" deleted successfully.`);
        }, 1000);
    });
};

export const listTasksPromise = () => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(tasks);
        }, 1000);
    });
};

// ===============================
// Task Manager - Async/Await Version
// ===============================

export const addTask = async (task) => {
    const message = await addTaskPromise(task);
    return message;
};

export const deleteTask = async (task) => {
    const message = await deleteTaskPromise(task);
    return message;
};

export const listTasks = async () => {
    const currentTasks = await listTasksPromise();
    return currentTasks;
};

