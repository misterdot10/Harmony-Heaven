using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeKeyboard : MonoBehaviour
{
    public KeyboardDisplay keyboardDisplay; // Referensi ke script KeyboardDisplay
    public KeyCode[] keyboardCodes;
    private KeyCode[] defaultKeyboardCodes = new KeyCode[5] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F };

    private void Start()
    {
        keyboardDisplay = GetComponent<KeyboardDisplay>(); // Mendapatkan referensi dari komponen KeyboardDisplay pada objek ini

        if (keyboardDisplay != null && keyboardDisplay.imageSprites != null)
        {
            int numberOfSprites = keyboardDisplay.imageSprites.Length;

            if (keyboardCodes == null || keyboardCodes.Length != numberOfSprites)
            {
                InitializeKeyboardCodes(numberOfSprites);
            }
        }
        else
        {
            Debug.LogError("Script KeyboardDisplay atau imageSprites tidak ditemukan atau belum diinisialisasi.");
        }
    }

    private void InitializeKeyboardCodes(int numberOfSprites)
    {
        keyboardCodes = new KeyCode[numberOfSprites];

        for (int i = 0; i < numberOfSprites; i++)
        {
            keyboardCodes[i] = defaultKeyboardCodes[i]; // Inisialisasi sesuai dengan default atau kebutuhan Anda.
        }
    }
}