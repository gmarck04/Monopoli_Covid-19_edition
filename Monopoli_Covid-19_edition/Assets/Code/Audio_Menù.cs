using UnityEngine;

public class Audio_Menù : MonoBehaviour
{
    private static readonly string BackgroundsPref = "BackgroundsPref";
    private static readonly string SoundsEffectsPref = "SoundsgroundsPref";
    private float BackgroundFloat, soundEffectFloat;
    public AudioSource backgroundAudio;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        BackgroundFloat = PlayerPrefs.GetFloat(BackgroundsPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundsEffectsPref);

        backgroundAudio.volume = BackgroundFloat;
    }
}
