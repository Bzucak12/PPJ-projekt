using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class LockerController : MonoBehaviour
{
    [Header("Stav skříňky")]
    [Tooltip("Je skříňka zamčená?")]
    public bool isLocked = false;
    public bool IsEndGame = false;
    public enum RequiredKey { Gold = 0, Silver = 1, Bronze = 2, None = 3 }
    public RequiredKey requiredKeyType;


    [Header("Komponenty a objekty")]
    [Tooltip("Animator komponenta na dveřích skříňky.")]
    public Animator doorAnimator;

    [Header("Zvukové efekty")]
    public AudioClip openSound;
    public AudioClip closeSound;
    public AudioClip lockedSound;
    public AudioClip unlockSound;

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
        if (IsEndGame)
        {
            if (InventoryManager.Instance.HasExitKey())
            {
                TryGetComponent<InventoryUI>(out InventoryUI InventoryUI);
                if (InventoryUI != null)
                {
                    InventoryUI.EnableContorol();
                    InventoryUI.ToggleInventory();
                }
                SceneManager.LoadScene("EndGame");
            }
            else
            {
                return;
            }
        }
        if (isLocked)
        {
            if (InventoryManager.Instance.HasKey(requiredKeyType))
            {// pokud hrac ma klic
                isLocked = false;
                if (unlockSound != null)
                {
                    audioSource.PlayOneShot(unlockSound);
                }
            }
            else
            {
                if (lockedSound != null)
                {
                    audioSource.PlayOneShot(lockedSound);
                }
                return;
            }
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
}