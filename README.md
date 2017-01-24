# CustomCollection2

To be honest I had to do some research into the inner workings of a dictionary for this project. My resources where from a .NET book that I own, some snippets from Stack Overflow, and the actual source code for a .NET dictionary which I didn’t have time to fully dissect. It was a very interesting project and I actually learned quite a lot about dictionaries, such as the fact that they use Hash tables and why they are so fast. 

I basically implemented a list with some generic key value pairs. They are strongly typed on instantiation and take any type of variable. I used Equals instead of the (==) operator and this does seem to compare objects as well as other variable types. 

I added some try catch blocks that will throw an error from a custom error class, but I did not implement the actual logging class for the errors, which I would normally do in a situation when I have more time. 

I added a custom Equals method that accounts for string case sensitivity but I probably could have done a better implementation for this. 

I did look up some optimizing improvements you can make for a dictionary. Some optimizations for a dictionary include increasing size instead of decreasing size. This allows for less hash collisions. You can also divide the dictionary into smaller pieces and read data from a dictionary in chunks. Shorter keys also helps. There are a handful of other dictionary optimization techniques that I read about here. – 
https://www.dotnetperls.com/optimization

Here are some of the resources I used
http://www.dotnetframework.org/default.aspx/4@0/4@0/DEVDIV_TFS/Dev10/Releases/RTMRel/ndp/clr/src/BCL/System/Collections/Generic/Dictionary@cs/1305376/Dictionary@cs
https://www.codeproject.com/Tips/126403/CustomDictionary-Class
http://stackoverflow.com/questions/6264794/create-dictionary-item-on-the-fly-with-operator
http://programmingwithmosh.com/csharp/csharp-collections/


1. This is a special case for a string. And it FORCES a dictionary to be case-insensitive. 
So if I tried to add HORSE and horse both as separate keys to my dictionary, it would fail, 
because the special case in this method REQUIRES (not ALLOWS FOR) case-insensitive strings. 
How might you make this work for either case? Similarly, what if you have a DateTime key and 
internally you want to disregard the “Time” part and only make your key off of Date? 
How would you do that? How would you do “what if…” for any key comparison a developer might
think of? Hint: see some of the overloaded constructors of .NET Dictionary<,> class.

I implemented the IEqualityComparer and made a couple of custom classes to compare different object types including a custom string comparison class, a custom date comparison class, and a custom Coordinate comparison class. I updated the Coordinate class by overriding the Equals and GetHashCode methods to allow for comparisons by reference and value. I changed the Add method to use the IEqualityComparer so that it will fail to add items if we use StringComparer.OrdinalIgnoreCare much like a real dictionary implementation. Now a developer can implement any type of IEqualityComparer they want and pass it in through the constructor at runtime. 

2. Read up on Some of the other “Try…” methods on MSDN. TryGetValue, TryParse. There’s something those methods do that 
your method doesn’t – or even more directly, there’s something your method is doing that the other methods don’t do.

My method had some extra functionality that was not needed. I changed it to function almost exactly how the TryGetValue works in 
a real Dictionary. I added a new function called GetKeyIndex that finds the index of the Key - first by checking that the hashes are equal then by checking if the key is equal. 

3. In some of your methods, you first call ContainsKey, and then you call the actual lookup. ContainsKey loops over the dictionary,
and then so does the lookup. Can you think of anything you could do to this method and others like it to prevent having to iterate 
over the list twice? How could you simplify things?

Yes I simplified it by removing the ContainsKey method and implemented the GetKeyIndex method mentioned above so that we are no longer interating over the list twice. 




