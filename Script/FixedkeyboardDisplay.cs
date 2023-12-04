using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedkeyboardDisplay : MonoBehaviour
{
    public Image[] imageComponents;
    public Sprite[] imageSprites;

    private void Start()
    {
        SetSpritesRandomly(); // Ganti pemanggilan ke metode yang menetapkan sprite secara acak.
    }

    private void SetSpritesRandomly()
    {
        // Pastikan jumlah elemen pada imageComponents sesuai dengan jumlah elemen pada imageSprites.
        if (imageComponents.Length == imageSprites.Length)
        {
            // Buat array baru untuk menyimpan indeks sprite yang sudah diacak.
            int[] randomIndexes = new int[imageSprites.Length];
            for (int i = 0; i < randomIndexes.Length; i++)
            {
                randomIndexes[i] = i;
            }

            // Acak indeks sprite.
            for (int i = 0; i < randomIndexes.Length; i++)
            {
                int temp = randomIndexes[i];
                int randomIndex = Random.Range(i, randomIndexes.Length);
                randomIndexes[i] = randomIndexes[randomIndex];
                randomIndexes[randomIndex] = temp;
            }

            // Tetapkan sprite secara acak ke komponen.
            for (int i = 0; i < imageComponents.Length; i++)
            {
                imageComponents[i].sprite = imageSprites[randomIndexes[i]];
            }
        }
        else
        {
            Debug.LogError("Jumlah imageComponents tidak sesuai dengan jumlah imageSprites. Sesuaikan elemen-elemen ini dengan benar.");
        }
    }
}