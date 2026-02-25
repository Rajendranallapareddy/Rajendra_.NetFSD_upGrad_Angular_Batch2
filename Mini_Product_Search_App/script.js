// ----------------------
// State Management
// ----------------------
const state = {
    products: [
        "iPhone 15",
        "Samsung Galaxy S24",
        "OnePlus 12",
        "MacBook Pro",
        "Dell XPS 13",
        "Sony Headphones",
        "Boat Earbuds",
        "iPad Air",
        "Apple Watch",
        "HP Pavilion"
    ],
    filteredProducts: []
};

// DOM Elements
const searchInput = document.getElementById("searchInput");
const productList = document.getElementById("productList");

// ----------------------
// Render Function
// ----------------------
function renderProducts(products) {
    productList.innerHTML = "";

    if (products.length === 0) {
        const li = document.createElement("li");
        li.textContent = "No Results Found";
        li.classList.add("no-results");
        productList.appendChild(li);
        return;
    }

    products.forEach(product => {
        const li = document.createElement("li");
        li.textContent = product;
        productList.appendChild(li);
    });
}

// ----------------------
// Filter Function
// ----------------------
function filterProducts(searchTerm) {
    state.filteredProducts = state.products.filter(product =>
        product.toLowerCase().includes(searchTerm.toLowerCase())
    );

    renderProducts(state.filteredProducts);
}

// ----------------------
// Event Listeners
// ----------------------

// Real-time filtering
searchInput.addEventListener("input", function (event) {
    filterProducts(event.target.value);
});

// Event Delegation (example click handler)
productList.addEventListener("click", function (event) {
    if (event.target.tagName === "LI" && 
        !event.target.classList.contains("no-results")) {
        alert("You selected: " + event.target.textContent);
    }
});

// ----------------------
// Initial Render
// ----------------------
renderProducts(state.products);