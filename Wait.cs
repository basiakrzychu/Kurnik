// C# program to illustrate the 
// concept of Join() method 
using System;
using System.Threading;

public class Wait
{

    // Non-Static method 
    public void mythread()
    {
        for (int x = 1; x <4; x++)
        {
            Console.WriteLine(x);
            Thread.Sleep(1000);
        }
    }

    // Non-Static method 
    public void mythread1()
    {
        Console.WriteLine("2nd thread is Working..");
    }
}

