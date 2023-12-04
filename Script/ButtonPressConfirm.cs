using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressConfirm : MonoBehaviour
{
    public int A = 0;
    private List<KeyCode> expectedKeyCodeSequence = new List<KeyCode>(); // Urutan key code yang diharapkan
    private List<KeyCode> currentInputSequence = new List<KeyCode>(); // Urutan key code yang sedang diinput
    public delegate void CorrectSequenceAction();
    public static event CorrectSequenceAction OnCorrectSequence;
    public KeyCodeConfirmation keyCodeConfirmation; // Referensi ke script KeyCodeConfirmation

    private void Start()
    {
        // Inisialisasi expectedKeyCodeSequence, misalnya dengan urutan WASD
        expectedKeyCodeSequence = new List<KeyCode> { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };

        // Mengatur referensi ke KeyCodeConfirmation jika belum diatur
        if (keyCodeConfirmation == null)
        {
            keyCodeConfirmation = FindObjectOfType<KeyCodeConfirmation>();
            if (keyCodeConfirmation == null)
            {
                Debug.LogError("Script KeyCodeConfirmation tidak ditemukan.");
            }
        }
    }

    private void Update()
    {
        if (keyCodeConfirmation != null)
        {
            // Loop melalui setiap kode tombol yang diharapkan
            for (int i = 0; i < keyCodeConfirmation.fixedkeyCodeKeyboard.keyboardCodes.Length; i++)
            {
                KeyCode expectedKeyCode = keyCodeConfirmation.fixedkeyCodeKeyboard.keyboardCodes[i];

                if (Input.GetKeyDown(expectedKeyCode))
                {
                    Debug.Log("Input diterima: " + expectedKeyCode);
                    VerifyInput(expectedKeyCode);
                }
            }
        }
        else
        {
            Debug.LogError("Script KeyCodeConfirmation tidak ditemukan.");
        }
    }

    private void VerifyInput(KeyCode input)
    {
        // Menyatakan input yang diterima
        currentInputSequence.Add(input);

        // Debugging: Cetak urutan input saat ini dan urutan yang diharapkan
        string currentSequenceStr = string.Join(", ", currentInputSequence);
        string expectedSequenceStr = string.Join(", ", expectedKeyCodeSequence);
        Debug.Log("Urutan Input Saat Ini: " + currentSequenceStr);
        Debug.Log("Urutan yang Diharapkan: " + expectedSequenceStr);

        // Memverifikasi apakah input yang diterima sesuai dengan urutan kode tombol yang seharusnya ditekan
        bool isCorrectSequence = CheckSequence(currentInputSequence, expectedKeyCodeSequence);
        Debug.Log("Urutan Benar? " + isCorrectSequence);

        if (isCorrectSequence)
        {
            A = 1;
            // Jika benar, kembali ke langkah 1 dengan membersihkan `currentInputSequence`.
            currentInputSequence.Clear();
            Debug.Log("Urutan Benar! Resetting...");
            if (OnCorrectSequence != null)
            {
                OnCorrectSequence();
            }
        }
        else
        {
            A = 0;
            // Jika salah, matikan hirarki objek yang dikendalikan
            Debug.Log("Urutan Salah! Matikan objek-objek...");
        }
    }

    // Metode untuk mengatur urutan key code yang diharapkan
    public void SetExpectedKeyCodeSequence(List<KeyCode> sequence)
    {
        expectedKeyCodeSequence = sequence;
    }

    private bool CheckSequence(List<KeyCode> current, List<KeyCode> expected)
    {
        if (current.Count != expected.Count)
        {
            return false;
        }

        for (int i = 0; i < current.Count; i++)
        {
            if (current[i] != expected[i])
            {
                return false;
            }
        }

        return true;
    }

    private void DeactivateObjects()
    {
        // Matikan hirarki objek yang dikendalikan
    }
}