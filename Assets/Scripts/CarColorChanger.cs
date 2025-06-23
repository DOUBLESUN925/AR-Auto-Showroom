using UnityEngine;

public class CarColorChanger : MonoBehaviour
{
    public Material[] carMaterials;
    private Renderer carRenderer;

    void Start()
    {
        carRenderer = GetComponentInChildren<Renderer>();
    }

    public void ChangeColor(int index)
    {
        if (index >= 0 && index < carMaterials.Length)
        {
            carRenderer.material = carMaterials[index];
        }
    }
}
