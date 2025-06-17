using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class KeyPickup : MonoBehaviour
{


    public float pickupDistance = 3f;
    public enum KeyType { Gold = 0, Silver = 1, Bronze = 2, None = 3 }
    public KeyType keyType;

    [Header("Zvukové efekty")]
    public AudioClip pickUpSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PickUp()
    {
        InventoryManager.Instance.AddKey(keyType);
        if (pickUpSound != null)
        {
            audioSource.PlayOneShot(pickUpSound);
        }
        Destroy(gameObject);
    }
}