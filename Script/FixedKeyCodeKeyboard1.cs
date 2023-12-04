using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedKeyCodeKeyboard1 : MonoBehaviour
{
    public FixedkeyboardDisplay keyboardDisplay;
    public KeyCode[] keyboardCodes;
    private KeyCode[] defaultKeyboardCodes = new KeyCode[5] { KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.F };

    private void Start()
    {
        keyboardDisplay = GetComponent<FixedkeyboardDisplay>();

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
            // Membaca nama sprite
            string spriteName = keyboardDisplay.imageSprites[i].name;

            // Menetapkan KeyCode berdasarkan nama sprite
            switch (spriteName)
            {
                case "11":
                    keyboardCodes[i] = KeyCode.DownArrow;
                    break;
                case "12":
                    keyboardCodes[i] = KeyCode.UpArrow;
                    break;
                case "10":
                    keyboardCodes[i] = KeyCode.LeftArrow;
                    break;
                case "13":
                    keyboardCodes[i] = KeyCode.RightArrow;
                    break;
                default:
                    // Default KeyCode jika tidak ada kecocokan
                    keyboardCodes[i] = defaultKeyboardCodes[i];
                    break;
            }
        }
    }
}