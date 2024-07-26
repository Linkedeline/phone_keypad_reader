using System;
using System.Text;
using System.Collections.Generic;

public class OldPhonePad
{
  // Dictionary mapping each number to its corresponding characters on an old phone keypad
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

    var result = new StringBuilder();
    char lastKey = '\0';
    int repeatCount = 0;

    foreach (char c in input)
    {
      switch (c)
      {
        case '#': 
          return result.ToString(); // End of input, return result
        case ' ': // reset Last Ket and repeatCount
          lastKey = '\0';
          repeatCount = 0; 
          continue; 
        case '*': 
          HandleBackspace(result, ref lastKey, ref repeatCount);
          continue;
        default:
          if (!keypadMapping.ContainsKey(c))
            throw new ArgumentException($"Invalid character in input: {c}");
            ProcessKeyPress(c, result, ref lastKey, ref repeatCount);
            break;
      }
    }
    return result.ToString(); // This line should never be reached due to '#' check
  }

  private static void HandleBackspace(StringBuilder result, ref char lastKey, ref int repeatCount)
  {
    if (result.Length > 0) result.Length--;
    lastKey = '\0';
    repeatCount = 0;
  }

  private static void ProcessKeyPress(char key, StringBuilder result, ref char lastKey, ref int repeatCount)
  {
    if (key == lastKey)
    {
      repeatCount = (repeatCount + 1) % keypadMapping[key].Length;
      result.Length--; // Remove the last character before adding the new one
    }
    else
    {
      lastKey = key;
      repeatCount = 0;
    }

    result.Append(keypadMapping[key][repeatCount]);
  }
}
