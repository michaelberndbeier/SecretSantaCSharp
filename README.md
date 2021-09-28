# Simple C# Implementation of a "Secret Santa"-shuffle

Mix nonidentical pairs of participants!

For a simple demo just call with:

~~~~
dotnet run
~~~~

This should print some demo pairs ;).

You can also call this program with you participants as parameters

~~~
dotnet run -- Michael Sara Toni Alice
~~~

And the final Trick

~~~
cat participants.txt | dotnet run
~~~
