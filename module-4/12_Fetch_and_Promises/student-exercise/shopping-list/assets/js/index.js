// An empty array that to load data
let list = [];

// A loadList function to fetch list items and load them into list array
function loadList() {

    const fetchURL = '.\assets\data\shopping-list.json'

    fetch(fetchURL)
        .then(
            (response) => {
                if (response.ok) {
                    response.json()
                        .then(json => {
                            list = json;
                            displayList();
                        })
                } else {
                    console.log(`Error: ${response}`);
                }
            }
        ).catch(err => {
            console.log(err);
        });
}

// Event listener for button. Calls loadList function
document.addEventListener('DOMContentLoaded', () => {
    const button = document.querySelector('a');
    button.addEventListener('click', () => {
        loadList();
        button.disabled = true;
    })
});

// A function to add shopping list items to the page
function displayList() {
    console.log('Populating Shopping List')

    if ('content' in document.createElement('template')) {
        const container = document.querySelector(".shopping-list-item-template")

        list.forEach((item) => {

            const temp = document.getElementById('.shopping-list >ul').content.cloneNode(true);

            temp.querySelector(".far fa-check-circle").className = item.completed;
            temp.querySelector("li").innerText = item.name;
            container.appendChild(temp);
        });
    }
}