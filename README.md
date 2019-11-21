# HackerNews
 Solution built in VS 2019 using .net core 3.0

Solution consists of the following projects
HackerNews - this is the console application taking input from the user
Please use the commandline argument --posts n. 
eg
From the executable folder 
hackernews --posts 2

will create 2 posts.

HackerNewsLibrary - this is a class library that does the following
- holds the data structure for a post
- does validation on every property in the Post class
- creates a JSON representation of the Post class

HackerNewsTest
- Carrys oout a set of MSTests on the validation class in HackerNewsLibrary

There is a Docker file created for a Windows image
Unfortualty docker debug can't accept a console input STDIN
