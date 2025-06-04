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

    void Update()
    {
        if (IsLookedAt(out RaycastHit hit))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryManager.Instance.AddKey(keyType); // přetypování na int
                Destroy(gameObject);
            }
        }
    }


    bool IsLookedAt(out RaycastHit hit)
    {
        Camera cam = Camera.main;
        return Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupDistance) && hit.transform == transform;
    }
}