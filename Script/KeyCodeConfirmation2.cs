using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeConfirmation2 : MonoBehaviour
{
    public FixedkeyboardDisplay fixedkeyboardDisplay; // Referensi ke script KeyboardDisplay
    public FixedKeyCodeKeyboard2 fixedkeyCodeKeyboard2; // Referensi ke script KeyCodeKeyboard

    void Start()
    {
        StartCoroutine(StartWithDelay());
    }

    private IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(2.0f); // Tunggu selama 2 detik

        if (fixedkeyboardDisplay != null && fixedkeyCodeKeyboard2 != null)
        {
            Debug.Log("Mendapatkan informasi ImageComponent...");
            int numberOfImageComponents = fixedkeyboardDisplay.imageComponents.Length;
            Debug.Log("Jumlah ImageComponent: " + numberOfImageComponents);

            for (int i = 0; i < numberOfImageComponents; i++)
            {
                Image imageComponent = fixedkeyboardDisplay.imageComponents[i];
                Sprite imageSprite = imageComponent.sprite;

                Debug.Log("Mengecek ImageSprite pada ImageComponent " + i + "...");
                string imageSpriteName = FindSpriteName(imageSprite);
                if (!string.IsNullOrEmpty(imageSpriteName))
                {
                    Debug.Log("Nama Sprite: " + imageSpriteName);
                    int spriteIndex = FindSpriteIndex(imageSpriteName);
                    if (spriteIndex != -1)
                    {
                        KeyCode keyCode = FindKeyCode(spriteIndex);
                        Debug.Log("ImageSprite " + i + " - Keycode: " + keyCode);
                    }
                    else
                    {
                        Debug.LogWarning("Tidak ada KeyCode yang sesuai untuk ImageSprite " + i);
                    }
                }
                else
                {
                    Debug.LogWarning("Nama Sprite tidak ditemukan untuk ImageSprite " + i);
                }
            }
        }
        else
        {
            Debug.LogError("Script KeyboardDisplay atau KeyCodeKeyboard tidak ditemukan.");
        }
    }

    private string FindSpriteName(Sprite imageSprite)
    {
        // Kode untuk menemukan nama Sprite dari imageSprite.
        // Gantilah ini dengan logika Anda sendiri.
        return imageSprite.name;
    }

    private int FindSpriteIndex(string spriteName)
    {
        for (int i = 0; i < fixedkeyboardDisplay.imageSprites.Length; i++)
        {
            if (spriteName == fixedkeyboardDisplay.imageSprites[i].name)
            {
                return i;
            }
        }
        return -1; // Jika tidak ditemukan
    }

    private KeyCode FindKeyCode(int spriteIndex)
    {
        if (spriteIndex >= 0 && spriteIndex < fixedkeyCodeKeyboard2.keyboardCodes.Length)
        {
            return fixedkeyCodeKeyboard2.keyboardCodes[spriteIndex];
        }
        else
        {
            Debug.LogWarning("Indeks sprite tidak valid: " + spriteIndex);
            return KeyCode.None; // Kode tombol default jika indeks tidak valid
        }
    }
}