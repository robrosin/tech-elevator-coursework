// add pageTitle
const pageTitle = 'My Shopping List';

// add groceries
const groceries = [{
    grocery: 'Eggs'
}, {
    grocery: 'Hummus'
}, {
    grocery: 'Onions'
}, {
    grocery: 'Butter'
}, {
    grocery: 'Spinach'
}, {
    grocery: 'Carrots'
}, {
    grocery: 'Garlic'
}, {
    grocery: 'Celery'
}, {
    grocery: 'Black Beans'
}, {
    grocery: 'Salt'
}];

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {

    // let pageTitle = document.getElementById('title');
    // pageTitle.innerText = name;

    document.getElementById('title').innerText = pageTitle;
};

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
    let grocery = document.getElementById('groceries');

    groceries.forEach(g => {
        let ele = document.createElement('li');
        ele.classList.add('grocery');
        ele.innerText = g.grocery;
        grocery.insertAdjacentElement('beforeend', ele);
    });
}

/**
 * This function will be called when the button is clicked. You will need to get a reference
 * to every list item and add the class completed to each one
 */

// // function markCompleted() {
// //     let ele = document.getElementsByClassName('groceries');
// //     for (let i = 0; i < ele.length; i++) {
// //         ele[i].style.setProperty = 'line-through';


// alert(document.getElementById("myP").style.textDecoration);
// }
function markCompleted() {
    document.getElementById('groceries').style.textDecorationLine = "line-through";
}


setPageTitle();

displayGroceries();

// Don't worry too much about what is going on here, we will cover this when we discuss events.
document.addEventListener('DOMContentLoaded', () => {
    // When the DOM Content has loaded attach a click listener to the button
    const button = document.querySelector('.btn');
    button.addEventListener('click', markCompleted);
});