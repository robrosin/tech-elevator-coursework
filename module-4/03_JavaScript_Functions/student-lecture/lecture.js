/***************************************************************************** */
/**
 * Some interesting behaviors of JavaScript. What will each of these lines show?
 */
function quirks() {
  // Adding and subtracting strings as numbers
  console.log(`'5' - '2' = ${'5' - '2'}`);
  console.log(`'5' + '2' = ${'5' + '2'}`);

  // Truthiness
  console.log(`0 == false = ${0 == false}`);
  console.log(`1 == true = ${1 == true}`);
  console.log(`2 == true = ${2 == true}`);

  console.log(`2 + true = ${2 + true}`);

  // Undeclared variables become global. 'use strict' to create an error
  x = 50;

  console.log([2, 11, 21, 1, 4, 32].sort());

  console.log(`Not-a-number is a ${typeof (NaN)}`);
  console.log(`(NaN === NaN) = ${(NaN === NaN)}`);
}


/*
########################
Function Overloading
########################

Function Overloading is not available in Javascript. If you declare a
function with the same name, more than one time in a script file, the
earlier ones are overridden and the most recent one will be used.
*/

function Add(num1, num2) {
  return num1 + num2;
}

function Add(num1, num2, num3) {
  return num1 + num2 + num3;
}

/**
 * How can I write the add function so that it will add any number of parameters?
 */



/***************************************************************** */
/***************  Array Functions  ******************************* */
/***************************************************************** */
function arrayFunctions()
{
  // Split a string into an array
    let phrase1 = "When in the course of human events it becomes necessary for one people to dissolve the political bands";
    // split here...
    let words;
    // call printArray here...
    


    console.log('*********************************')
    console.log('array.slice get a "sub-array" but does not modify the original' );
    // slice here...
    let arr;
    printArray(arr);
    printArray(words);
    

    console.log('*********************************')
    console.log('array.splice get a "sub-array" and removes those elements.' );
    // splice here...
    printArray(arr);
    printArray(words);


    console.log('*********************************')
    console.log('array.concat joins two arrays, and does not modify either.' );
    // concat here...
    let bigArray;
    printArray(words);
    printArray(arr);
    printArray(bigArray);

}

/**
 * Joins an array of strings together with the - separator and prints to console.
 * @param {string[]} arr The array to be printed
 */
function printArray(arr){
  console.log(arr.join("-"));
}




/*********************************************************
 * Anonymous Functions
 * 
 * Functions are a "first-class object" in JavaScript.  
 * There are numerous ways to define functions.  We have seen just one 
 * way so far... with the "function" keyword similar to how we define a method in C#.
 */
// Anonymous functions
function doubleIt(n){
  return n * 2;
}

/***************************
 * There is actually a "variable" called doubleIt now
 */
// print it...



/************************
 * Now that the function is defined, we can actually "assign" that function to 
 * another variable.
 */


// Call the function doubleIt



// Call the function f



/*****************************
 * Another way to define a function - assign it to a variable directly
 * 
 */



/*******************************
 * And finally, a shortcut for the above using lambda (fat arrow)
 * 
 */


/************************************
 * You may even see a shorter-cut, called an expression-bodied function
 * but I won't use it normally
 */


 
/************************************
 * Now we can write a function, which takes another function as a parameter.
 * The passed-in function can be called (executed / invoked).
 */
function toAllElements(array, functionToApply){

}

/***********************************
 * Define an array of numbers
 */
let myArray = [1,2,3,4,5];

/**********************************
 * Now in the Console window, call toAllElements, passing in myArray, and a function
 * which will perform an operation on every element
 */
//toAllElements(myArray, doubleIt);






/*************************************************************************************
 * Using Anonymous functions
 * ***********************************************************************************
 */

 /**
 * Takes an array and returns a new array of only numbers that are
 * multiples of 3
 *
 * @param {number[]} numbersToFilter numbers to filter through
 * @returns {number[]} a new array with only those numbers that are
 *   multiples of 3
 */
function allDivisibleByThree(numbersToFilter) {}


/**
 * Takes an array and, using the power of anonymous functions, generates
 * their sum.
 *
 * @param {number[]} numbersToSum numbers to add up
 * @returns {number} sum of all the numbers
 */
function sumAllNumbers(numbersToSum) {
  return numbersToSum.reduce();
}





let people = [
  { name: "name", age: 21, height: 71 },
];


// List all the people using foreach
function listAllPeople(people) {
}

// Filter people by height or age
function shortPeople(people) {
}

// Map Name to uppercase
function upperName(people) {
}


// Reduce to total height of all people
function totalHeight(people) {
}



