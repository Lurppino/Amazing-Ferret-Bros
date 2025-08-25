using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Variables")]
    public int MaxHealth = 3;
    public int healt;
    public bool canDoubleJump = false;
    public bool canGlide = false;

    private HealthBar healthBar;

    private void Start()
    {
        healt = MaxHealth;
        healthBar = FindFirstObjectByType<HealthBar>();
        healthBar.UpdateHealthBar(MaxHealth);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RemoveHealth(1);
        }
    }
    public void ApplyEffect(Item item)
    {
        switch(item.itemName)
        {
            case "Heal":
                healt = Mathf.Min(3, healt + 1);
                healthBar.UpdateHealthBar(healt);
                break;
            case "DoubleJump":
                canDoubleJump = true;
                Debug.Log("Double Jump enabled!");
                break;
            case "Glide":
                canGlide = true;
                Debug.Log("Glide enabled!");
                break;
            default:
                Debug.LogWarning("Unkwown instant effect: " + item.itemName);
                break;
        }
    }
    public void RemoveHealth(int amount)
    {
        healt -= amount;
        healthBar.UpdateHealthBar(healt);
    }
}
