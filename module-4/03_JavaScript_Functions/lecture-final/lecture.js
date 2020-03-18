/***************************************************************************** */
/**
 * Some interesting behaviors of JavaScript. What will each of these lines show?
 */
function quirks() {
  // Adding and subtracting strings as numbers
  console.log(`'5' - '2' = ${'5' - '2'}`);  // 3
  console.log(`'5' + '2' = ${'5' + '2'}`);  // 52

  // Truthiness
  console.log(`0 == false = ${0 == false}`);  // true
  console.log(`1 == true = ${1 == true}`);    // true
  console.log(`2 == true = ${2 == true}`);    // true

  console.log(`2 + true = ${2 + true}`);      // true

  // Undeclared variables become global. 'use strict' to create an error
  x = 50;

  console.log([2, 11, 21, 1, 4, 32].sort());  // [1, 2, 4, 11, 21, 32]

  console.log(`Not-a-number is a ${typeof (NaN)}`); // Number
  console.log(`(NaN === NaN) = ${(NaN === NaN)}`);  // false
  let n = NaN;
  console.log(`(n === n) = ${(n === n)}`);  // false
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
function Add(){
  let sum = 0;
  for (let i = 0; i < arguments.length; i++)
  {
    arg = arguments[i];
    if ( typeof(arg) === "number"){
      sum += arguments[i];
    }
  }
  return sum;
}



/***************************************************************** */
/***************  Array Functions  ******************************* */
/***************************************************************** */
function arrayFunctions()
{
  // Split a string into an array
    let phrase1 = "When in the course of human events it becomes necessary for one people to dissolve the political bands";
    // split here...
    let words = phrase1.split(" ");

    // call printArray here...
    printArray(words);    


    console.log('*********************************')
    console.log('array.slice get a "sub-array" but does not modify the original' );
    // slice here...
    let arr = words.slice(3, 7);
    printArray(arr);
    printArray(words);
    

    console.log('*********************************')
    console.log('array.splice get a "sub-array" and removes those elements.' );
    // splice here...
    arr = words.splice(3, 4, "middle", "of", "the", "day");
    printArray(arr);
    printArray(words);


    console.log('*********************************')
    console.log('array.concat joins two arrays, and does not modify either.' );
    // concat here...
    let bigArray = words.concat(arr);
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
console.log(`doubleIt is type: ${typeof(doubleIt)}`);



/************************
 * Now that the function is defined, we can actually "assign" that function to 
 * another variable.
 */
let func = doubleIt;  // Point a new variable to the same function
console.log(`func is type: ${typeof(func)}`);



// Call the function doubleIt
console.log(doubleIt(25));


// Call the function f
console.log(func(125));



/*****************************
 * Another way to define a function - assign it to a variable directly
 * 
 */
let tripleIt = function(n) {
  return n*3;
}


/*******************************
 * And finally, a shortcut for the above using lambda (fat arrow)
 * 
 */
let quadrupleIt = (n) => { 
  return n*4; 
}

// Multiple parameters
let addEm = (x, y) => { return x + y; };

// Arguments is not defined error.
// let addEmAll = () => {
//   let sum = 0;
//   for (let i = 0; i < arguments.length; i++)
//   {
//     sum += arguments[i];
//   }
//   return sum;
// }

/************************************
 * You may even see a shorter-cut, called an expression-bodied function
 * but I won't use it normally
 */
let quintupleIt = n => n * 5;


 
/************************************
 * Now we can write a function, which takes another function as a parameter.
 * The passed-in function can be called (executed / invoked).
 */
function toAllElements(array, functionToApply){
  let result = [];

  for (let i = 0; i < array.length; i++){
    // Apply the function to each element and put that value in the new array
    let n = functionToApply(array[i]);
    result.push(n);
  }
  return result;
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
function allDivisibleByThree(numbersToFilter) {
  return numbersToFilter.filter(
    ele => {
      return (ele % 3 === 0);
    }
  )
}


/**
 * Takes an array and, using the power of anonymous functions, generates
 * their sum.
 *
 * @param {number[]} numbersToSum numbers to add up
 * @returns {number} sum of all the numbers
 */
function sumAllNumbers(numbersToSum) {
  return numbersToSum.reduce(
    (sum, ele) => {
      return sum + ele;
    }, 0
  );
}


let people = [
  { name: "Andrew", age: 42, height: 76 },
  { name: "Richard", age: 57, height: 74 },
  { name: "Rachel", age: 36, height: 67 },
  { name: "Chris", age: 32, height: 67 },
  { name: "Amy", age: 39, height: 62 },
];


// List all the people using foreach
function listAllPeople(people) {
  people.forEach( (p) => {
    console.log(`${p.name} is ${p.height} inches tall.`);
  }  );
}

// Filter people by height or age
function shortPeople(people) {
  return people.filter( p => p.height < 70);
}

// Map Name to uppercase
function upperName(people) {
  return people.map( p => p.name.toUpperCase());
}


// Reduce to total height of all people
function totalHeight(people) {
}


/***********
 * Sort an array of number as if they were numbers!
 */
function sortByAge(people){
  return people.sort(
    (p1, p2) => p1.age - p2.age
  )
}
  
  function sortDescendingByAge(people){
    return people.sort(
      (p1, p2) => p2.age - p1.age
    );
  }
