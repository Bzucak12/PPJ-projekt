using UnityEngine;
using UnityEngine.UI;

public class TabSwitcher : MonoBehaviour
{
    public GameObject inventoryPage;
    public GameObject questsPage;
    public GameObject mapPage;

    public Button inventoryButton;
    public Button questsButton;
    public Button mapButton;

    void Start()
    {
        inventoryButton.onClick.AddListener(() => ShowTab("inventory"));
        questsButton.onClick.AddListener(() => ShowTab("quests"));
        mapButton.onClick.AddListener(() => ShowTab("map"));
        ShowTab("inventory"); // výchozí stránka
    }

    public void ShowTab(string tabName)
    {
        inventoryPage.SetActive(tabName == "inventory");
        questsPage.SetActive(tabName == "quests");
        mapPage.SetActive(tabName == "map");
    }
}