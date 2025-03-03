using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryCanvas;
    private bool isOpen = false;

    void Start()
    {
        inventoryCanvas.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            inventoryCanvas.SetActive(isOpen);
            
            if (isOpen)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }
}