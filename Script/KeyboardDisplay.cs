using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardDisplay : MonoBehaviour
{
    public Image[] imageComponents;
    public Sprite[] imageSprites;
    public Sprite[] imageSprites22;

    private void Start()
    {
        RandomQuest();
    }

    public void RandomQuest()
    {
        for (int i = 0; i < imageComponents.Length; i++)
        {
            int randomInt = Random.Range(0, imageSprites.Length);
            ShowSprite(i, randomInt);
        }
    }

    private void ShowSprite(int idxComponents, int idxSprite)
    {
        imageComponents[idxComponents].sprite = imageSprites[idxSprite];
    }
}
