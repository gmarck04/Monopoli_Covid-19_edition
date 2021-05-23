using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static readonly string BackgroundsPref = "BackgroundsPref";
    private static readonly string SoundsEffectsPref = "SoundsgroundsPref";
    private float BackgroundFloat, soundEffectFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] SoundEffectaudio;

    void Awake()
    {
        ContinueSettings(); //richiamo funzione ContinueSettings, che setta le impostazioni audio
    }

    private void ContinueSettings()
    {
        BackgroundFloat = PlayerPrefs.GetFloat(BackgroundsPref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundsEffectsPref);

        backgroundAudio.volume = BackgroundFloat;

        for (int i = 0; i < SoundEffectaudio.Length; i++)
        {
            SoundEffectaudio[i].volume = soundEffectFloat;
        }
    }
}
