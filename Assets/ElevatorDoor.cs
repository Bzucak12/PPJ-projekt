using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class ElevatorDoor : MonoBehaviour
{
    [Header("Stav skříňky")]
    [Tooltip("Je skříňka zamčená?")]
    public bool isLocked = false;
    public enum RequiredKey { Gold = 0, Silver = 1, Bronze = 2 }
    public RequiredKey requiredKeyType;

    [Header("Komponenty a objekty")]
    [Tooltip("Animator komponenta na dveřích skříňky.")]
    public Animator doorAnimatorLeft;
    public Animator doorAnimatorRight;

    [Header("Zvukové efekty")]
    public AudioClip openSound;
    public AudioClip closeSound;

    public bool IsOpen { get; private set; } = false;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (isLocked)
        {
            if (InventoryManager.Instance.HasKeyElevator(requiredKeyType))
            {// pokud hrac ma klic
                isLocked = false;
            }
            else
            {
                return;
            }
        }

        // Změna stavu otevření
        IsOpen = !IsOpen; // Používáme novou property

        if (IsOpen)
        {
            doorAnimatorLeft.SetTrigger("Open");
            doorAnimatorRight.SetTrigger("Open");
            if (openSound != null)
            {
                audioSource.PlayOneShot(openSound);
            }
        }
        else
        {
            doorAnimatorLeft.SetTrigger("Close");
            doorAnimatorRight.SetTrigger("Close");
            if (closeSound != null)
            {
                audioSource.PlayOneShot(closeSound);
            }
        }
    }
}
