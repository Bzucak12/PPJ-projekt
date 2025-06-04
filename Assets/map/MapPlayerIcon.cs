using UnityEngine;
using UnityEngine.UI;

public class MapPlayerIcon : MonoBehaviour
{
    public RectTransform playerIcon;
    public RectTransform mapImage;
    public Transform playerTransform;

    public Vector2 worldMin = new Vector2(-50, -50);
    public Vector2 worldMax = new Vector2(50, 50);

    void Update()
    {
        Vector3 worldPos = playerTransform.position;

        float normalizedX = Mathf.InverseLerp(worldMin.x, worldMax.x, worldPos.x);
        float normalizedY = Mathf.InverseLerp(worldMin.y, worldMax.y, worldPos.z);

        float mapWidth = mapImage.rect.width;
        float mapHeight = mapImage.rect.height;

        float uiX = normalizedX * mapWidth;
        float uiY = normalizedY * mapHeight;

        playerIcon.anchoredPosition = new Vector2(uiX, uiY);
    }
}
