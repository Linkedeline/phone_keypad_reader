# OldPhonePad Converter

This project implements an OldPhonePad converter in C#, which simulates the text input method used on old mobile phone keypads. It converts a sequence of number key presses into the corresponding text.

## Features

- Converts number sequences to their corresponding letters based on old phone keypad layout
- Handles repeated key presses to cycle through available letters
- Supports backspace functionality using the `*` character
- Ignores spaces in the input
- Requires `#` at the end of each input to signify completion

## How It Works

The converter uses the following keypad mapping:

- 1: &'(
- 2: ABC
- 3: DEF
- 4: GHI
- 5: JKL
- 6: MNO
- 7: PQRS
- 8: TUV
- 9: WXYZ
- 0: (space)

Repeated presses of the same key cycle through the available letters. For example, pressing '2' once gives 'A', twice gives 'B', and three times gives 'C'.

## Usage

To use the OldPhonePad converter, call the `ConvertToOldPhonePad` method of the `OldPhonePad` class:

```csharp
string result = OldPhonePad.ConvertToOldPhonePad("228#");
Console.WriteLine(result); // Output: BAT
```

Make sure to end each input with '#' to signify the end of the input sequence.

## Examples

1. Basic conversion:
   ```csharp
   OldPhonePad.ConvertToOldPhonePad("33#") // Returns: E
   ```

2. Using backspace:
   ```csharp
   OldPhonePad.ConvertToOldPhonePad("227*#") // Returns: B
   ```

3. Spelling a word:
   ```csharp
   OldPhonePad.ConvertToOldPhonePad("4433555 555666#") // Returns: HELLO
   ```

4. Complex input:
   ```csharp
   OldPhonePad.ConvertToOldPhonePad("8 88777444666*664#") // Returns: TURING
   ```

## Error Handling

The converter will throw an `ArgumentException` in the following cases:
- If the input is empty
- If the input doesn't end with '#'
- If the input contains invalid characters (anything not in the keypad mapping or special characters)

## Contributing

Feel free to fork this project and submit pull requests with improvements or bug fixes. If you find any issues, please open an issue in the project repository.

## License

This project is open source and available under the [MIT License](https://opensource.org/licenses/MIT).
