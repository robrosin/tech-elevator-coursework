let allItemsIncomplete = true;
const pageTitle = 'My Shopping List';
const groceries = [
    { id: 1, name: 'Oatmeal', completed: false },
    { id: 2, name: 'Milk', completed: false },
    { id: 3, name: 'Banana', completed: false },
    { id: 4, name: 'Strawberries', completed: false },
    { id: 5, name: 'Lunch Meat', completed: false },
    { id: 6, name: 'Bread', completed: false },
    { id: 7, name: 'Grapes', completed: false },
    { id: 8, name: 'Steak', completed: false },
    { id: 9, name: 'Salad', completed: false },
    { id: 10, name: 'Tea', completed: false }
];

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
    const title = document.getElementById('title');
    title.innerText = pageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
    const ul = document.querySelector('ul');
    groceries.forEach((item) => {
        const li = document.createElement('li');
        li.innerText = item.name;
        const checkCircle = document.createElement('i');
        checkCircle.setAttribute('class', 'far fa-check-circle');
        li.appendChild(checkCircle);
        ul.appendChild(li);
    });
}

// Toggles 'Mark All Complete' and 'Mark All Incomplete', making allItemsIncomplete true or false accordingly

function markAll() {
    const items = document.querySelectorAll('li');
    const button = document.getElementById('toggleAll');

    items.forEach(item => {
        addRemoveCompleted(item);
    });
    allItemsIncomplete = !allItemsIncomplete;
    if (allItemsIncomplete) {
        button.innerText = 'Mark All Complete';
    } else {
        button.innerText = "Mark All Incomplete";
    }
};

function addRemoveCompleted(item) {
    if (allItemsIncomplete) {
        item.classList.add('completed');
        item.querySelector('i').classList.add('completed');
    } else {
        item.classList.remove('completed');
        item.querySelector('i').classList.remove('completed');
    }
}

// Marks one item as complete upon single click
function markOne(item) {
    item.classList.add('completed');
}

// Marks one item as incomplete upon double click
function unMarkOne(item) {
    item.classList.remove('completed');
}

function complete(item) {
    if (!item.classList.contains('completed')) {
        item.classList.add('completed');
        item.querySelector('i').classList.add('completed');
    }
}

function incomplete(item) {
    if (item.classList.contains('completed')) {
        item.classList.remove('completed');
        item.querySelector('i').classList.remove('completed');
    }
}

// Calls markOne or unMarkOne when individual item is clicked
document.addEventListener('DOMContentLoaded', () => {
    setPageTitle();
    displayGroceries();

    let items = document.querySelectorAll('li');
    items.forEach(item => {
        item.addEventListener('click', markOne(item));
        item.addEventListener('dblclick', unMarkOne(item));
    });

    let button = document.getElementById('toggleAll');
    button.addEventListener('click', markAll);
});