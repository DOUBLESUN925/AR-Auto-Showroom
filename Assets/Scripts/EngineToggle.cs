using UnityEngine;

public class EngineToggle : MonoBehaviour
{
    public AudioSource engineAudio;
    private bool isEngineOn = false;

    public void ToggleEngine()
    {
        isEngineOn = !isEngineOn;
        if (isEngineOn)
            engineAudio.Play();
        else
            engineAudio.Stop();
    }
}
