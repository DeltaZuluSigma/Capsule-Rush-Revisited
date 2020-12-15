using System.Collections;
using System.Collections.Generic;

public class RandNum
{
    private static readonly System.Random getrandom = new System.Random();

    public static int GetRandomNumber(int min, int max)
    {
        lock (getrandom) // synchronize
        {
            return getrandom.Next(min, max);
        }
    }
}
