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
            // Kontrola pro sebrateln� p�edm�ty
            if (hit.collider.TryGetComponent<ItemPickup>(out var item))
            {
                interactionHintText.text = "Pick Up Item"; // M��ete si p�elo�it
                interactionHintText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    item.PickUp();
                    // N�pov�du nen� t�eba skr�vat zde, skryje se v dal��m sn�mku, pokud u� nic nedetekujeme
                }
            }
            // Kontrola pro sebrateln� kl��e
            else if (hit.collider.TryGetComponent<KeyPickup>(out var key))
            {
                interactionHintText.text = "Pick Up Item"; // M��ete si p�elo�it
                interactionHintText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    key.PickUp();
                }
            }
            // --- NOV� ��ST PRO SK���KU ---
            // Kontrola pro sk���ku
            else if (hit.collider.TryGetComponent<LockerController>(out var locker))
            {
                // Zobraz�me n�pov�du a nastav�me spr�vn� text podle stavu sk���ky
                interactionHintText.gameObject.SetActive(true);

                if (locker.isLocked)
                {

                    interactionHintText.text = "Locked";
                }
                else if (locker.IsOpen)
                {
                    interactionHintText.text = "Close";
                }
                else
                {
                    interactionHintText.text = "Open";
                }

                // Pokud hr�� stiskne kl�vesu E, zavol�me metodu Interact() na sk���ce
                if (Input.GetKeyDown(KeyCode.E))
                {
                    locker.Interact();
                }
            }
            // --- KONEC NOV� ��STI ---
            else if (hit.collider.TryGetComponent<ElevatorDoor>(out var elevator))
            {
                // Zobraz�me n�pov�du a nastav�me spr�vn� text podle stavu sk���ky
                interactionHintText.gameObject.SetActive(true);

                if (elevator.isLocked)
                {
                    
                    interactionHintText.text = "Locked";
                }
                else if (elevator.IsOpen)
                {
                    interactionHintText.text = "Close";
                }
                else
                {
                    interactionHintText.text = "Open";
                }

                // Pokud hr�� stiskne kl�vesu E, zavol�me metodu Interact() na sk���ce
                if (Input.GetKeyDown(KeyCode.E))
                {
                    elevator.Interact();
                }
            }
            else if (hit.collider.TryGetComponent<ElevatorTeleporter>(out var teleport))
            {
                // Zobraz�me n�pov�du a nastav�me spr�vn� text podle stavu sk���ky
                interactionHintText.gameObject.SetActive(true);

                interactionHintText.text = "Teleport";

                // Pokud hr�� stiskne kl�vesu E, zavol�me metodu Interact() na sk���ce
                if (Input.GetKeyDown(KeyCode.E))
                {
                    teleport.TeleportPlayer();
                }
            }
            else
            {
                // Pokud se d�v�me na n�co, s ��m nelze interagovat, skryjeme n�pov�du
                interactionHintText.gameObject.SetActive(false);
            }
        }
        else
        {
            // Pokud se ned�v�me na nic, skryjeme n�pov�du
            interactionHintText.gameObject.SetActive(false);
        }
    }
}