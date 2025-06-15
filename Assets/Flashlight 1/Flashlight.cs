using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool isOn = false;

    public float maxBatteryTime = 30f;
    private float currentBatteryTime;

    public Image batteryProgressBar;
    public TextMeshProUGUI batteryCountText;

    void Start()
    {
        flashlight.SetActive(false);
        currentBatteryTime = maxBatteryTime;
        UpdateUI();
    }

    void OnEnable()
    {
        InventoryManager.OnItemCountChanged += OnInventoryChanged;
    }

    void OnDisable()
    {
        InventoryManager.OnItemCountChanged -= OnInventoryChanged;
    }

    private void OnInventoryChanged(string itemName)
    {
        if (itemName == "Battery")
        {
            UpdateUI();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("F"))
        {
            if (!isOn && (currentBatteryTime > 0 || InventoryManager.Instance.GetItemCount("Battery") > 0))
                TurnOnFlashlight();
            else if (isOn)
                TurnOffFlashlight();
        }

        if (isOn)
        {
            currentBatteryTime -= Time.deltaTime;

            if (currentBatteryTime <= 0)
            {
                if (InventoryManager.Instance.UseItem("Battery"))
                {
                    currentBatteryTime = maxBatteryTime;
                }
                else
                {
                    TurnOffFlashlight();
                    currentBatteryTime = 0;
                }
            }

            UpdateUI();
        }
    }

    void TurnOnFlashlight()
    {
        flashlight.SetActive(true);
        if (turnOn != null)
            turnOn.Play();
        isOn = true;
        UpdateUI();
    }

    void TurnOffFlashlight()
    {
        flashlight.SetActive(false);
        if (turnOff != null)
            turnOff.Play();
        isOn = false;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (batteryProgressBar != null)
            batteryProgressBar.fillAmount = currentBatteryTime / maxBatteryTime;

        if (batteryCountText != null)
            batteryCountText.text = "Baterries: " + InventoryManager.Instance.GetItemCount("Battery");
    }
}