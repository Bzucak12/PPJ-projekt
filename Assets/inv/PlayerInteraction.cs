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
            if (hit.collider.TryGetComponent<ItemPickup>(out var item))
            {
                interactionHintText.text = "Pick Up Item";
                interactionHintText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    item.PickUp();
                    interactionHintText.gameObject.SetActive(false);
                }
            }
            else if (hit.collider.TryGetComponent<KeyPickup>(out var key))
            {
                interactionHintText.text = "Pick Up Key";
                interactionHintText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    key.PickUp();
                    interactionHintText.gameObject.SetActive(false);
                }
            }
            else
            {
                interactionHintText.gameObject.SetActive(false);
            }
        }
        else
        {
            interactionHintText.gameObject.SetActive(false);
        }
    }
}
