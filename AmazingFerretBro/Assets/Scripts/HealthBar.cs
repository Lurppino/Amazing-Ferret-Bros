using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour
{
    private List<Image> images = new List<Image>();
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        foreach(Transform child in transform)
        {
            images.AddRange(child.GetComponentsInChildren<Image>());
        }
    }
    public void UpdateHealthBar(int newHealth)
    {
        for (int i = 0; i < newHealth; i++)
        {
            images[i].sprite = fullHeart;
        }
        for (int i = newHealth; i < images.Count; i++)
        {
            images[i].sprite = emptyHeart;
        }
    }
}
