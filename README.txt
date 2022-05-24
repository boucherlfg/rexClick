Rex click lets you create scripts for automating some tasks related to mouse and keyboard.

It is a console application, meaning there is no graphic user interface. 

There are a couple example projects in the repo, if you want to start easy.

I added a notepad++ style template to the repo, if you want to use it.

I also added a batch file for setting associations for rex click with .rex files.

You can juste type "help" in the command line at any stage, and you will get information about available commands.

The two only unhelped contents in the app are the maths module and the flow control (in scripts) so here are the possible operations : 

MATHS

+ a b : adds two numbers
- a b : subtracts two numbers
* a b : multiplies two numbers
/ a b : divides two numbers
^ a b : yields the power two numbers

= a b : checks if two numbers are equal
!= a b : checks if two numbers are not equal
< a b : checks if a is strictly less than b
> a b : checks if a is strictly more than b
<= a b : checks if a is less or equal to b
>= a b : checks if a is more or equal to b
 
rand : yields a random decimal from 0 to 1
_ num : floors the given number
~ num : returns 1 if number is 0, 1 otherwise
  
FLOW

!flag : tells the script to go to corresponding flag
:flag : indicates a flag. script will pass this instruction
/comment : indicates a comment. script will pass this instruction
?(expression)!flag : indicates a conditional jump. it will go to given flag only if expression evaluates to anything but 0
%n : you can pass arguments to scripts via console. Those arguments will be represented in scripts as %0, %1, %2...

To start a script, you need to either : 
1. use the console, and type "app run filename.txt".
2. drag and drop the script on the .exe file
3. double click it (if it's a .rex file, and you have used the association batch file)

example : 

var set a 0
:start
console print (var get a)
var set a (+ (var get a) 1)
!start

This will print numbers from 0, incrementing 1 each time, up to when you stop the script.
