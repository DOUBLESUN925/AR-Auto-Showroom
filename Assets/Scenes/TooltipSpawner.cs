using UnityEngine;

public class TooltipSpawner : MonoBehaviour
{
    public GameObject tooltipPrefab;
    public string tooltipText = "Part Info Here";

    private GameObject spawnedTooltip;

    void Start()
    {
        if (tooltipPrefab)
        {
            spawnedTooltip = Instantiate(tooltipPrefab, transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity);
            spawnedTooltip.transform.SetParent(GameObject.Find("Canvas").transform, false); // parent to UI Canvas

            var textComponent = spawnedTooltip.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            if (textComponent)
            {
                textComponent.text = tooltipText;
            }
        }
    }
}
