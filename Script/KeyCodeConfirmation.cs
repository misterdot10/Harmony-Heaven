using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeConfirmation : MonoBehaviour
{
    public FixedkeyboardDisplay fixedkeyboardDisplay; // Referensi ke script KeyboardDisplay
    public FixedKeyCodeKeyboard fixedkeyCodeKeyboard; // Referensi ke script FixedKeyCodeKeyboard

    private List<GameObject> objectsToControl = new List<GameObject>(); // Objek-objek yang akan dikontrol

    void Start()
    {
        // Panggil fungsi CompileConfirmation dengan penundaan 1 detik.
        Invoke("CompileConfirmation", 1f);
    }

    void CompileConfirmation()
    {
        if (fixedkeyboardDisplay != null && fixedkeyCodeKeyboard != null)
        {
            // Debugging: Mendapatkan informasi ImageComponent
            Debug.Log("Mendapatkan informasi ImageComponent...");
            int numberOfImageComponents = fixedkeyboardDisplay.imageComponents.Length;
            Debug.Log("Jumlah ImageComponent: " + numberOfImageComponents);

            List<KeyCode> expectedKeyCodeSequence = new List<KeyCode>();

            for (int i = 0; i < numberOfImageComponents; i++)
            {
                Image imageComponent = fixedkeyboardDisplay.imageComponents[i];
                Sprite imageSprite = imageComponent.sprite;

                // Debugging: Mengecek ImageSprite pada ImageComponent
                Debug.Log("Mengecek ImageSprite pada ImageComponent " + i + "...");
                string imageSpriteName = FindSpriteName(imageSprite);
                if (!string.IsNullOrEmpty(imageSpriteName))
                {
                    // Debugging: Nama Sprite yang ditemukan
                    Debug.Log("Nama Sprite: " + imageSpriteName);
                    
                    int spriteIndex = FindSpriteIndex(imageSpriteName);
                    if (spriteIndex != -1)
                    {
                        KeyCode keyCode = FindKeyCode(spriteIndex);
                        // Debugging: Keycode yang ditemukan
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

            // Setelah selesai, berikan urutan key code yang diharapkan ke KeyCodeConfirmation
            SetExpectedKeyCodeSequence(expectedKeyCodeSequence);
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
        if (spriteIndex >= 0 && spriteIndex < fixedkeyCodeKeyboard.keyboardCodes.Length)
        {
            return fixedkeyCodeKeyboard.keyboardCodes[spriteIndex];
        }
        else
        {
            Debug.LogWarning("Indeks sprite tidak valid: " + spriteIndex);
            return KeyCode.None; // Kode tombol default jika indeks tidak valid
        }
    }

    // Metode untuk mengatur urutan key code yang diharapkan
    private void SetExpectedKeyCodeSequence(List<KeyCode> sequence)
    {
        // Mengirim urutan key code yang diharapkan ke ButtonPressConfirm
        ButtonPressConfirm buttonPressConfirm = FindObjectOfType<ButtonPressConfirm>();
        if (buttonPressConfirm != null)
        {
            buttonPressConfirm.SetExpectedKeyCodeSequence(sequence);
        }
        else
        {
            Debug.LogError("Script ButtonPressConfirm tidak ditemukan.");
        }
    }

    // Metode untuk mengembalikan objek-objek yang akan dikontrol
    public List<GameObject> GetObjectsToControl()
    {
        // Anda perlu mengisi daftar objek-objek yang akan dikontrol sesuai dengan kebutuhan Anda
        // Contoh sederhana: Daftar objek yang akan dikontrol adalah objek di bawah script ini
        foreach (Transform child in transform)
        {
            objectsToControl.Add(child.gameObject);
        }
        return objectsToControl;
    }
}