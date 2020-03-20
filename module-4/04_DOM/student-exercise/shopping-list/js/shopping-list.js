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

    document.querySelector('#title').innerText = pageTitle;

};

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
    let grocery = document.getElementById('shopping-list > groceries');

    groceries.forEach(g => {
        // create a div element
        let ul = document.createElement('ul');
        // add 'class' review to div element
        ul.classList.add('grocery');
        addGrocery(ul, g.groceries);
        main.insertAdjacentElement('beforeend', ul);
    });


    /**
     * This function will be called when the button is clicked. You will need to get a reference
     * to every list item and add the class completed to each one
     */
    function markCompleted() {}

    setPageTitle();

    displayGroceries();

    // Don't worry too much about what is going on here, we will cover this when we discuss events.
    document.addEventListener('DOMContentLoaded', () => {
        // When the DOM Content has loaded attach a click listener to the button
        const button = document.querySelector('.btn');
        button.addEventListener('click', markCompleted);
    });