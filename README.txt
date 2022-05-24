# rexClick
Rex click lets you create scripts for automating some tasks related to mouse and keyboard.

It is a console application, meaning there is no graphic user interface. 

There are a couple example projects in the repo, if you want to start easy.

I added a notepad++ style template to the repo, if you want to use it.

I also added a batch file for setting associations for rex click with .rex files.

You can juste type "help" in the command line at any stage, and you will get information about available commands.

The two only unhelped contents in the app are the maths module and the flow control (in scripts) so here are the possible operations : 

MATHS

* + a b : adds two numbers
* - a b : subtracts two numbers
* * a b : multiplies two numbers
* / a b : divides two numbers
* ^ a b : yields the power two numbers

* = a b : checks if two numbers are equal
* != a b : checks if two numbers are not equal
* < a b : checks if a is strictly less than b
* > a b : checks if a is strictly more than b
* <= a b : checks if a is less or equal to b
* >= a b : checks if a is more or equal to b
 
* rand : yields a random decimal from 0 to 1
* _ num : floors the given number
* ~ num : returns 1 if number is 0, 1 otherwise
  
FLOW

* !flag : tells the script to go to corresponding flag
* :flag : indicates a flag. script will pass this instruction
* /comment : indicates a comment. script will pass this instruction
* ?(expression)!flag : indicates a conditional jump. it will go to given flag only if expression evaluates to anything but 0
