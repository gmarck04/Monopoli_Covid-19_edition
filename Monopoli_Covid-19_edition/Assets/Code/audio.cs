using UnityEngine;
using UnityEngine.UI;

public class audio : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundsPref = "BackgroundsPref";
    private static readonly string SoundsEffectsPref = "SoundsgroundsPref";
    private int firstPlayInt;
    public Slider BackgroundSlider, soundEffectSlider;
    private float BackgroundFloat, soundEffectFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] SoundEffectaudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0) //se il valore è uguale a 0
        {
            BackgroundFloat = .125f;
            soundEffectFloat = .75f;
            BackgroundSlider.value = BackgroundFloat;
            soundEffectSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(BackgroundsPref, BackgroundFloat);
            PlayerPrefs.SetFloat(SoundsEffectsPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else //valore è un diverso da 0
        {
            BackgroundFloat = PlayerPrefs.GetFloat(BackgroundsPref); //prende valore da BackgroundsPref
            BackgroundSlider.value = BackgroundFloat;
            soundEffectFloat = PlayerPrefs.GetFloat(SoundsEffectsPref); //prende valore da SoundsEffectsPref
            soundEffectSlider.value = soundEffectFloat;
        }
    }
    public void SavesoundsSettings() //salvataggio impostazioni audio
    {
        PlayerPrefs.SetFloat(BackgroundsPref, BackgroundSlider.value);
        PlayerPrefs.SetFloat(SoundsEffectsPref, soundEffectSlider.value);
    }
    void OnApplicationFocus(bool infocus)
    {
        if(!infocus) //se infocus è false
        {
            SavesoundsSettings();
        }
    }
    public void UpdateSound() //aggiorna i valori delle impostazioni audio
    {
        backgroundAudio.volume = BackgroundSlider.value;

        for(int i = 0; i < SoundEffectaudio.Length; i++)
        {
            SoundEffectaudio[i].volume = soundEffectSlider.value;
        }
    }
}