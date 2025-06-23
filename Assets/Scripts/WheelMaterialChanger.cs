using UnityEngine;

public class WheelMaterialChanger : MonoBehaviour
{
    public GameObject car; // Drag the active car prefab here
    public Material[] wheelMaterials; // Assign your wheel materials
    private int currentIndex = 0;

    public void ChangeWheelMaterial()
    {
        if (car == null || wheelMaterials.Length == 0) return;

        // Find wheels by name (ensure names match your hierarchy)
        string[] wheelNames = { "Front_Left_Wheel", "Front_Right_Wheel", "Rear_Left_Wheel", "Rear_Right_Wheel" };

        foreach (string wheelName in wheelNames)
        {
            Transform wheel = car.transform.Find(wheelName);
            if (wheel != null)
            {
                Renderer rend = wheel.GetComponent<Renderer>();
                if (rend != null)
                {
                    rend.material = wheelMaterials[currentIndex];
                }
            }
        }

        currentIndex = (currentIndex + 1) % wheelMaterials.Length;
    }
}
