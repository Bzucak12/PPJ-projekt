using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LockerController : MonoBehaviour
{
    [Header("Stav skříňky")]
    [Tooltip("Je skříňka zamčená?")]
    public bool isLocked = false;

    [Header("Komponenty a objekty")]
    [Tooltip("Animator komponenta na dveřích skříňky.")]
    public Animator doorAnimator;

    [Header("Zvukové efekty")]
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip lockedSound;

    // --- ZMĚNA ZDE ---
    // Zpřístupníme stav pouze pro čtení (public get)
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
            if (lockedSound != null)
            {
                audioSource.PlayOneShot(lockedSound);
            }
            return;
        }

        // Změna stavu otevření
        IsOpen = !IsOpen; // Používáme novou property

        if (IsOpen)
        {
            doorAnimator.SetTrigger("Open");
            if (openSound != null)
            {
                audioSource.PlayOneShot(openSound);
            }
        }
        else
        {
            doorAnimator.SetTrigger("Close");
            if (closeSound != null)
            {
                audioSource.PlayOneShot(closeSound);
            }
        }
    }

    public void Unlock()
    {
        isLocked = false;
    }
}