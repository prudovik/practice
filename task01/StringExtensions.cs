namespace task01;

using System;

public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
        input = input.ToLower();
        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsPunctuation(input, i) || Char.IsWhiteSpace(input, i))
            {
                input = input.Remove(i, 1);
                i--;
            }
        }
        if (input == "") return false;
        for (int i = 0; i < input.Length / 2; i++)
        {
            if (input[i] != input[input.Length - (1 + i)]) return false;
        }
        return true;
    }
}
