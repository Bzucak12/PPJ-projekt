using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    public float pickupDistance = 3f;
    public enum KeyType { Gold = 0, Silver = 1, Bronze = 2 }
    public KeyType keyType;

    public void PickUp()
    {
        InventoryManager.Instance.AddKey(keyType);
        Destroy(gameObject);
    }
}