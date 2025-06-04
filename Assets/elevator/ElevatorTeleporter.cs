using UnityEngine;
using System.Collections; // ← MUSÍ TU BÝT, jinak nefunguje IEnumerator

public class ElevatorTeleporter : MonoBehaviour
{
    public Transform destination;
    public GameObject player;
    public Animator doorAnimator;

    private bool isPlayerInElevator = false;

    void Update()
    {
        if (isPlayerInElevator && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(TeleportPlayer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInElevator = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInElevator = false;
        }
    }

    private IEnumerator TeleportPlayer()
    {
        // Zavři dveře (pokud máš animátor)
        if (doorAnimator != null)
            doorAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(1f); // čas na zavření dveří

        // Teleportuj hráče
        if (player != null && destination != null)
            player.transform.position = destination.position;

        yield return new WaitForSeconds(1f); // čas na otevření dveří

        if (doorAnimator != null)
            doorAnimator.SetTrigger("Open");
    }
}