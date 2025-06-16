using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f;
    public Camera playerCamera;
    public TextMeshProUGUI interactionHintText;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Kontrola pro sebratelné pøedmìty
            if (hit.collider.TryGetComponent<ItemPickup>(out var item))
            {
                interactionHintText.text = "Pick Up Item"; // Mùžete si pøeložit
                interactionHintText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    item.PickUp();
                    // Nápovìdu není tøeba skrývat zde, skryje se v dalším snímku, pokud už nic nedetekujeme
                }
            }
            // Kontrola pro sebratelné klíèe
            else if (hit.collider.TryGetComponent<KeyPickup>(out var key))
            {
                interactionHintText.text = "Pick Up Item"; // Mùžete si pøeložit
                interactionHintText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    key.PickUp();
                }
            }
            // --- NOVÁ ÈÁST PRO SKØÍÒKU ---
            // Kontrola pro skøíòku
            else if (hit.collider.TryGetComponent<LockerController>(out var locker))
            {
                // Zobrazíme nápovìdu a nastavíme správný text podle stavu skøíòky
                interactionHintText.gameObject.SetActive(true);

                if (locker.isLocked)
                {
                    interactionHintText.text = "Is Locked";
                }
                else if (locker.IsOpen)
                {
                    interactionHintText.text = "Close Locker";
                }
                else
                {
                    interactionHintText.text = "Open Locker";
                }

                // Pokud hráè stiskne klávesu E, zavoláme metodu Interact() na skøíòce
                if (Input.GetKeyDown(KeyCode.E))
                {
                    locker.Interact();
                }
            }
            // --- KONEC NOVÉ ÈÁSTI ---
            else
            {
                // Pokud se díváme na nìco, s èím nelze interagovat, skryjeme nápovìdu
                interactionHintText.gameObject.SetActive(false);
            }
        }
        else
        {
            // Pokud se nedíváme na nic, skryjeme nápovìdu
            interactionHintText.gameObject.SetActive(false);
        }
    }
}