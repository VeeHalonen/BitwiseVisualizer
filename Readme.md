# BitwiseVisualizer

<p>This was a practice project to better familiarize myself with C# as well as bitwise operations. This is why C#'s built-in conversion methods were not used.</p>

<p>The <b>Bitwise class</b> stores a single non-negative integer value and a text string representing the corresponding binary number. Objects are initialized with the integer representation of the number, which is then converted to binary in the constructor.</p>

<p>The class has static methods to convert any given value from binary to decimal or vice versa. Meanwhile, the class methods include the bitwise operators AND, OR, XOR, NOT, LEFT SHIFT, and RIGHT SHIFT. Each of these methods returns a new object, as opposed to modifying the current one. There are also print methods for demonstrating the effects of each operation on the calling object. These utilize the "infamous" Thread.Sleep method in order to print the results of the different operations one by one in a timed fashion. The ToString method is also overridden.</p>

<p>The <b>Main class</b> is a simple example program demonstrating the Bitwise class. When launched, the program asks the user for a number. This number is then converted into a Bitwise object, and the operations NOT, LEFT SHIFT, and RIGHT SHIFT are immediately demonstrated using one of the timed print methods described above.</p>

```
*** Welcome to Bitwise Visualizer! ***

Give number or (Q)uit: 12

NOT
00001100 (12)
=
11110011 (243)

00001100 (12)
 << 1
=
00011000 (24)

00001100 (12)
 >> 1
=
00000110 (6)

```
<p>After this, the user is asked to give a binary string, which is then used to create another Bitwise object, and the rest of the operations are demonstrated. The bitstrings' lengths are equalized during printing in order to facilitate the comparisons.</p>

```
Give a binary string: 13

Not a valid binary string.
Binary strings can only have 1s and 0s.

Give a binary string: 10101110000110

00000000001100 (12)
AND
10101110000110 (11142)
=
00000000000100 (4)


00000000001100 (12)
OR
10101110000110 (11142)
=
10101110001110 (11150)


00000000001100 (12)
XOR
10101110000110 (11142)
=
10101110001010 (11146)


Press Enter to Continue
```
<p>After the user presses Enter, the screen gets cleared and the user is returned to the beginning of the program.</p>
<p>Typing "Q", "q", "quit", "QUIT", or "Quit" instead of a number exits the program.</p>
