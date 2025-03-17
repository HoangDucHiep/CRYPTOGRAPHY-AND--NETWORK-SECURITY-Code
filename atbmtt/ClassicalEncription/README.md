## 🙆 This is just a brief note on key points in the code, not a general note on encryption.

## CaesarCipher Encription

- `Encoded = (plain + key) % 26` (26 is number of letters in English alphabet)
- Since here i use [ASCII](https://www.ascii-code.com/) value for character manipulation, so

  ```csharp
  var offset = c.IsUpperCase() ? 'A' : 'a';
  ```

  use for transforming the value between (0, 1, 2, ..., 25) value and ASCII value

* That's all to note for this simple encription :))

## Vigenere Cipher

### Autokey problems

- The only thing to talk here is AutoKey decoded, because the **processed key** *(the processed key used in decode process)* consists of both **key (user input)** and **plain text ** - what we need to find :>
- So we need to reconstruct step by step.

#### Example:

Given:

* Ciphertext: **"LXFOPVEFRNHR"**
* Key: **"LEMON"**

##### Step 1: Decrypt first 5 characters using the key

| Cipher | Key | Plain |
| ------ | --- | ----- |
| L      | L   | A     |
| X      | E   | T     |
| F      | M   | T     |
| O      | O   | A     |
| P      | N   | C     |

Decrypted so far: **"ATTAC"**

##### Step 2: Extend the key with decrypted text

New key: **"LEMONATTAC"**

##### Step 3: Continue decryption

| Cipher | Key | Plain |
| ------ | --- | ----- |
| V      | A   | V     |
| E      | T   | H     |
| F      | T   | I     |
| R      | A   | R     |
| N      | C   | L     |
| H      | K   | X     |
| R      | E   | N     |

Final plaintext: **"ATTACKVIRLXN"**

### "Key" characteristics

* The plaintext can contain white space, non-letter character, ...
* So this is an example of how Key constructed
  * plain text: "er 13 lazyasd"
  * input key: "cryptii"
  * processed key: "cr 13 yptiicr" (repeat)
* We just ***skip any non-letter character***
