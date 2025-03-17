## CaesarCipher Encription

- `Encoded = (plain + key) % 26` (26 is number of letters in English alphabet)
- Because here i use [ASCII](https://www.ascii-code.com/) value for character, so

  ```csharp
  var offset = c.IsUpperCase() ? 'A' : 'a';
  ```

    use for transfer the value between (0, 1, 2, ..., 25) value and ASCII 		 value

* That's all to note for this simple encription :))


## Vigenere Cipher

- There are 2 types of Vinegere ( At least in this code :> )
  - Repeat key
  - Autokey
