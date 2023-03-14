const cars = ['Tesla', 'Mercedes', 'Honda']
const [ randomCar ] = cars
const [ ,otherRandomCar ] = cars
//Predict the output
console.log(randomCar) 
// This console log is finding the first item in the list and executing it
console.log(otherRandomCar)
// this console log runs and gathers the next item in the list since the first log grabbed the first already



const employee = {
    name: 'Elon',
    age: 47,
    company: 'Tesla'
}
const { name: otherName } = employee;
//Predict the output
console.log(employee);
// This console log isn't going to identify the object because the name is different from the object changing it to employee would fix this issue
console.log(otherName);
// this console log will pull the "name" key vaule which is elon


const person = {
    name: 'Phil Smith',
    age: 47,
    height: '6 feet'
}
const password = '12345';
const { password: hashedPassword } = person;  
//Predict the output
console.log(password);
// this console log is pulling the password set "12345"
console.log(hashedPassword);
// in the dict the password is set so it returns indefined



const numbers = [8, 2, 3, 5, 6, 1, 67, 12, 2];
const [,first] = numbers;
const [,,,second] = numbers;
const [,,,,,,,,third] = numbers;
//Predict the output
console.log(first == second);
// with the == is checking for bool values in which returns false
console.log(first == third);
// same with the first console log this returns true



const lastTest = {
    key: 'value',
    secondKey: [1, 5, 1, 8, 3, 3]
}
const { key } = lastTest;
const { secondKey } = lastTest;
const [ ,willThisWork] = secondKey;
//Predict the output
console.log(key);
// this is pulling the key's value
console.log(secondKey);
// this is pulling the key's value which is the list of numbers
console.log(secondKey[0]);
// this is pulling the list and pulling the value out of the 0th index
console.log(willThisWork);
// this is pulling the list as for the second key since the 0th key was called already it moves to the next value stored into the index 1











