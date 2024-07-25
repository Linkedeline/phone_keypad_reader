using System;
using System.Text;
using System.Collections.Generic;

public class OldPhonePad
{
    private static readonly Dictionary<char, string> keypadMapping = new Dictionary<char, string>
    {
        {'1', "&'("}, {'2', "ABC"}, {'3', "DEF"},
        {'4', "GHI"}, {'5', "JKL"}, {'6', "MNO"},
        {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"},
        {'0', " "}
    };

    public static string ConvertToOldPhonePad(string input)
    {
        if (string.IsNullOrEmpty(input) || !input.EndsWith("#"))
            throw new ArgumentException("Input must not be empty and must end with '#'");

        StringBuilder result = new StringBuilder();
        char lastKey = '\0';
        int repeatCount = 0;

        foreach (char c in input)
        {
            if (c == '#')
                break;

            if (c == ' ')
                continue;

            if (c == '*')
            {
                if (result.Length > 0)
                    result.Length--;
                lastKey = '\0';
                repeatCount = 0;
                continue;
            }

            if (!keypadMapping.ContainsKey(c))
                throw new ArgumentException($"Invalid character in input: {c}");

            if (c == lastKey)
            {
                repeatCount = (repeatCount + 1) % keypadMapping[c].Length;
                result.Length--; // Remove the last character before adding the new one
            }
            else
            {
                lastKey = c;
                repeatCount = 0;
            }

            result.Append(keypadMapping[c][repeatCount]);
        }

        return result.ToString();
    }
}
