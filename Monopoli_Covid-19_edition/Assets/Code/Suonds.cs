using UnityEngine;

public class Suonds : MonoBehaviour
{
    public AudioSource Music_slider;

    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Music_slider.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Music_slider.volume = musicVolume;
    }
    public void updateVolume( float volume)
    {
        musicVolume = volume;
    }
}
