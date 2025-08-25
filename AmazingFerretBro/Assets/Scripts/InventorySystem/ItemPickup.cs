using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    [Header("Animation parameters")]
    public float floatAmplitude = 0.25f;
    public float floatFrequency = 1.0f;
    public float rotationSpeed = 50f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        transform.Rotate(0,0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Inventory inventory = collision.GetComponent<Inventory>();
        if(player == null) return;
        switch(item.type)
        {
            case ItemType.Instant:
                player.ApplyEffect(item);
                break;
            case ItemType.Storable:
                if(inventory != null)
                    inventory.AddItem(item);
                break;
            case ItemType.Passive:
                player.ApplyEffect(item);
                break;
        }
        Destroy(gameObject);
    }
}
