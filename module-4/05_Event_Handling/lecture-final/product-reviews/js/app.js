const name = 'Cigar Parties for Dummies';
let description = 'Host and plan the perfect cigar party for all of your squirrelly friends.';
let reviews = [
  {
    reviewer: 'Malcolm Gladwell',
    title: 'What a book!',
    review:
      "It certainly is a book. I mean, I can see that. Pages kept together with glue (I hope that's glue) and there's writing on it, in some language.",
    rating: 3
  }
];

/**
 * Add our product name to the page title
 * Get our page page title by the id and the query the .name selector
 * once you have the element you can add the product name to the span.
 */
function setPageTitle() {
  const pageTitle = document.getElementById('page-title');
  pageTitle.querySelector('.name').innerText = name;
}

/**
 * Add our product description to the page.
 */
function setPageDescription() {
  document.querySelector('.description').innerText = description;
}

/**
 * I will display all of the reviews in the reviews array
 */
function displayReviews() {
  // Clear the reviews from the html
  const reviewsDiv = document.getElementById('reviews');
  reviewsDiv.innerHTML = '';
  if ('content' in document.createElement('template')) {
    reviews.forEach((review) => {
      displayReview(review);
    });
  } else {
    console.error('Your browser does not support templates');
  }
}

/**
 *
 * @param {Object} review The review to display
 */
function displayReview(review) {
  const tmpl = document.getElementById('review-template').content.cloneNode(true);
  tmpl.querySelector('h4').innerText = review.reviewer;
  tmpl.querySelector('h3').innerText = review.title;
  tmpl.querySelector('p').innerText = review.review;
  // there will always be 1 star because it is a part of the template
  for (let i = 2; i <= review.rating; ++i) {
    const img = tmpl.querySelector('img').cloneNode();
    tmpl.querySelector('.rating').appendChild(img);
  }
  const reviewsDiv = document.getElementById('reviews');
  reviewsDiv.appendChild(tmpl);
}

// LECTURE STARTS HERE ---------------------------------------------------------------

// TODO 01: Add an event listener for DOMContentLoaded and call the methods below only once that event occurs. We are going to hook up more event handlers,
// so let's clean it up by creating an initializePage function to do all our setup stuff.

document.addEventListener('DOMContentLoaded', initializePage)

function initializePage() {
  // set the product reviews page title
  setPageTitle();
  // set the product reviews page description
  setPageDescription();
  // display all of the product reviews on our page
  displayReviews();

  // Handle click on description, and show input box while hiding desc
  let desc = document.querySelector('.description');
  desc.addEventListener('click', (ev) => {
    toggleDescriptionEdit(desc);
  });

  // Handle keyup on the desc edit
  let inputDesc = document.getElementById('inputDesc');
  inputDesc.addEventListener('keyup', (ev) => {
    if (ev.key === 'Enter') {
      exitDescriptionEdit(ev.target, true);
    }
    else if (ev.key === 'Escape') {
      exitDescriptionEdit(ev.target, false);
    }
  });

  // Also handle blur, same as escape
  inputDesc.addEventListener('blur', (ev) => {
    exitDescriptionEdit(ev.target, false);
  });

  // Handle the show / hide form button for adding a review
  document.getElementById('btnToggleForm').addEventListener('click', (v) => {
    showHideForm();
  });

  // Handle the form submit for adding a review
  let form = document.querySelector('form');
  form.addEventListener('submit', (ev) => {
    saveReview();
    ev.preventDefault();
  });

}
// TODO 02: Allow the user to update the Description
// TODO 02a: Handle 'click' on the description, and show the edit box, while hiding the p with the description in it
// TODO 02b: Handle the keyup event to determine when the user is done editting. If the user pressed Enter, save the desc. If they pressed Esc, quit without saving
//            For all other keys, let the event bubble up.
// TODO 02c: Also handle the blur event on the textbox, which does the same as Esc (quit without saving).

// TODO 03: Allow the user to add a new Review
// TODO 03a: Handle the click event of the Add Review button. Show the form (call showHideForm())
// TODO 03c: Handle the click event of the Save Review button, and call saveReview().

/**
 * Take an event on the description and swap out the description for a text box.
 *
 * @param {Event} event the event object
 */
function toggleDescriptionEdit(desc) {
  const textBox = desc.nextElementSibling;
  textBox.value = description;
  textBox.classList.remove('d-none');
  desc.classList.add('d-none');
  textBox.focus();
}

/**
 * Take an event on the text box and set the description to the contents
 * of the text box and then hide the text box and show the description.
 *
 * @param {Event} event the event object
 * @param {Boolean} save should we save the description text
 */
function exitDescriptionEdit(textBox, save) {
  let desc = textBox.previousElementSibling;
  if (save) {
    description = textBox.value;
    setPageDescription();
  }
  textBox.classList.add('d-none');
  desc.classList.remove('d-none');
}

// TODO 03b: Implement Show/Hide form.
/**
 * I will show / hide the add review form.
 */
function showHideForm() {
  /*
    If the form is hidden:
      * Show the form
      * Set the button text to 'Hide Form' or 'Cancel'
      * Set the input focus to the name field
    Else
      * Clear the form (call resetFormValues())
      * Hide the form
      * Set the button text back to 'Add Review'
  */
  const form = document.querySelector('form');
  const button = document.getElementById('btnToggleForm');
  if (form.classList.contains('d-none')) {
    form.classList.remove('d-none');
    button.innerText = 'Cancel';
  }
  else {
    form.classList.add('d-none');
    resetFormValues();
    button.innerText = 'Add Review';
  }

}

/**
 * I will reset all of the values in the form.
 */
function resetFormValues() {
  const form = document.querySelector('form');
  const inputs = form.querySelectorAll('input');
  inputs.forEach((input) => {
    input.value = '';
  });
  document.getElementById('rating').value = 1;
  document.getElementById('review').value = '';
}

// TODO 03d: Implement saveReview
// TODO 03e: should the new review show up on the top or bottom of the list?
/**
 * I will save the review that was added using the add review from
 */
function saveReview() {
  /*
* Get references to all the form controls (name, title, review, rating)
* Create a new Javascript object for the Review, and set those 4 properties
* Add the review to the collection of reviews. 
* Call displayReview, passing in the new review
* Hide the form (call showHideForm)
*/

  let newReview = {
    reviewer: document.getElementById('name').value,
    title: document.getElementById('title').value,
    review: document.getElementById('review').value,
    rating: document.getElementById('rating').value
  }

  reviews.unshift(newReview);
  displayReviews();
  showHideForm();

}
