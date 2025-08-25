using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    public Inventory inventory;
    public Image[] slotImages;

    private void Update()
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (i < inventory.inventory.Count && inventory.inventory[i] != null)
            {
                slotImages[i].sprite = inventory.inventory[i].icon;
                slotImages[i].enabled = true;
            }
            else
            {
                slotImages[i].sprite = null;
                slotImages[i].enabled = false;
            }
        }
    }
}
