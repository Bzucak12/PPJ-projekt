using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;

    public Button inventoryButton;

    public GameObject inventoryPage;
    public MouseLook mouseLook; // přiřaď v inspektoru (kamera s MouseLook)

    private bool isOpen = false;

    void Start()
    {
        inventoryPanel.SetActive(false);
        ShowPage(inventoryPage);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isOpen = false;
    }

    public void ToggleInventory()
    {
        isOpen = !isOpen;
        inventoryPanel.SetActive(isOpen);

        if (isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mouseLook.enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            mouseLook.enabled = true;
        }
    }

    void ShowPage(GameObject page)
    {
        inventoryPage.SetActive(false);
        page.SetActive(true);
    }

    // Pokud chceš, můžeš tlačítka připojit v inspektoru k těmto metodám:
    public void ShowInventoryPage() => ShowPage(inventoryPage);

    public void EnableContorol()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        mouseLook.enabled = false;
    }
}