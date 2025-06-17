using UnityEngine;
using System.Collections; // ← MUSÍ TU BÝT, jinak nefunguje IEnumerator

public class ElevatorTeleporter : MonoBehaviour
{
    public Transform destination;
    public GameObject player;
    public Animator doorAnimatorOriginalLeft;
    public Animator doorAnimatorOriginalRight;
    public Animator doorAnimatorDestinationLeft;
    public Animator doorAnimatorDestinationRight;

    public void TeleportPlayer()
    {
        //Zavři dveře (pokud máš animátor)
        doorAnimatorOriginalLeft.SetTrigger("Close");
        doorAnimatorOriginalRight.SetTrigger("Close");

        // yield return new WaitForSeconds(1f); // čas na zavření dveří

        // Teleportuj hráče
        if (player != null && destination != null)
        {
            //player.transform.position = destination.position;
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.Teleport(destination.position);
            }
        }

        //yield return new WaitForSeconds(1f); // čas na otevření dveří

        doorAnimatorDestinationLeft.SetTrigger("Open");
        doorAnimatorDestinationRight.SetTrigger("Open");
        
    }
}