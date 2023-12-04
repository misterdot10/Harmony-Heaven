using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedKeyCodeKeyboard2 : MonoBehaviour
{
    public FixedkeyboardDisplay keyboardDisplay; // Mengubah referensi ke FixedkeyboardDisplay
    public KeyCode[] keyboardCodes;
    private KeyCode[] defaultKeyboardCodes = new KeyCode[5] { KeyCode.D, KeyCode.S, KeyCode.A, KeyCode.W, KeyCode.F };

    private void Start()
    {
        keyboardDisplay = GetComponent<FixedkeyboardDisplay>(); // Mengubah referensi ke FixedkeyboardDisplay.

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
            Debug.LogError("Script FixedkeyboardDisplay atau imageSprites tidak ditemukan atau belum diinisialisasi.");
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