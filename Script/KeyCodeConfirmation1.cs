using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeConfirmation1 : MonoBehaviour
{
    public FixedKeyCodeKeyboard1 fixedKeyCodeKeyboard1; // Referensi ke script FixedKeyCodeKeyboard1
    public FixedkeyboardDisplay fixedkeyboardDisplay; // Referensi ke script FixedkeyboardDisplay

    private List<GameObject> objectsToControl = new List<GameObject>(); // Objek-objek yang akan dikontrol

    void Start()
    {
        // Panggil fungsi CompileConfirmation dengan penundaan 1 detik.
        Invoke("CompileConfirmation", 1f);
    }

    void CompileConfirmation()
    {
        if (fixedkeyboardDisplay != null && fixedKeyCodeKeyboard1 != null)
        {
            Debug.Log("Mendapatkan informasi ImageComponent...");
            int numberOfImageComponents = fixedkeyboardDisplay.imageComponents.Length;
            Debug.Log("Jumlah ImageComponent: " + numberOfImageComponents);

            List<KeyCode> expectedKeyCodeSequence = new List<KeyCode>();

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

                        // Menambahkan ke urutan key code yang diharapkan
                        expectedKeyCodeSequence.Add(keyCode);
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

            // Setelah selesai, berikan urutan key code yang diharapkan ke ButtonPressConfirm1
            ButtonPressConfirm1 buttonPressConfirm1 = FindObjectOfType<ButtonPressConfirm1>();
            if (buttonPressConfirm1 != null)
            {
                buttonPressConfirm1.SetExpectedKeyCodeSequence(expectedKeyCodeSequence);
            }
            else
            {
                Debug.LogError("Script ButtonPressConfirm1 tidak ditemukan.");
            }
        }
        else
        {
            Debug.LogError("Script FixedkeyboardDisplay atau FixedKeyCodeKeyboard1 tidak ditemukan.");
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
        if (spriteIndex >= 0 && spriteIndex < fixedKeyCodeKeyboard1.keyboardCodes.Length)
        {
            return fixedKeyCodeKeyboard1.keyboardCodes[spriteIndex];
        }
        else
        {
            Debug.LogWarning("Indeks sprite tidak valid: " + spriteIndex);
            return KeyCode.None; // Kode tombol default jika indeks tidak valid
        }
    }
}