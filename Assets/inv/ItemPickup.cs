using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class ItemPickup : MonoBehaviour
{
    public string itemName = "Lektvar";
    public bool isKey = false;
    public KeyPickup.KeyType keyType;  // místo int

    [Header("Zvukové efekty")]
    public AudioClip pickUpSound;

    public float pickupDistance = 3f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (IsLookedAt(out RaycastHit hit))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isKey)
                {
                    InventoryManager.Instance.AddKey(keyType);
                }
                else
                {
                    InventoryManager.Instance.AddItem(itemName);
                }
                if (pickUpSound != null)
                {
                    audioSource.PlayOneShot(pickUpSound);
                }

                Destroy(gameObject);
            }
        }
    }

    public void PickUp()
    {
        InventoryManager.Instance.AddItem(itemName);
        Destroy(gameObject);
    }

    bool IsLookedAt(out RaycastHit hit)
    {
        Camera cam = Camera.main;
        return Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupDistance)
               && hit.transform == transform;
    }
}