/* Problem 1.	Function Playground
Create a function with no parameters. Perform the following operations:
•	The function should print the number of its arguments and each of the arguments' type. 
o	Call the function with different number and type of arguments.
•	The function should print the this object. Compare the results when calling the function from:
o	Global scope
o	Function scope
o	Over the object
o	Use call and apply to call the function with parameters and without parameters */

function myFunction() {
    
    console.log(this.name);

    var argsLength = arguments.length;
    console.log("Number of arguments: " + argsLength);
    
    for (key in arguments) {
        console.log(key + ". Value: " + arguments[key] + ", Type: " + typeof arguments[key]);
    }

    console.log();
}

var func = function() {
    var obj = {};
    obj.name = "Pesho";
    return obj;
}

myFunction(4, 5, 6, true , 7, 3, "shalala", func);

myFunction.call({ name: "myfunctionCalled" }, "string", "anotherString", 8);

myFunction.apply({ name: "myFunctionApplied" }, [4, 6, 43, "yes"]);