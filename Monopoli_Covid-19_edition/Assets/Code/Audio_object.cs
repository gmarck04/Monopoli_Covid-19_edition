using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_object : MonoBehaviour
{
    public AudioSource backgroundAudio;
    public AudioSource[] SoundEffectaudio;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); //non distrugge l'audio
    }
}
