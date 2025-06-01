
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static  readonly string FirstPlay =  "FirstPlay";
    public static readonly string Music = "Music";
    public static readonly string Sounds = "Sounds";
    private int FirstPlayInt;
    public Slider MusicSlider, SoundSlider;
    private float musicFloat,soundsFloat;

    public AudioSource MusicAudio;
    public AudioSource[] SoundEffects;

    void Start()
    {
        FirstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(FirstPlayInt == 0)
        {
            musicFloat = 0.25f;
            soundsFloat = 0.75f;
            MusicSlider.value = musicFloat;
            SoundSlider.value = soundsFloat;
            PlayerPrefs.SetFloat(Music, musicFloat);
            PlayerPrefs.SetFloat(Sounds, soundsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(Music);
            MusicSlider.value = musicFloat;
            soundsFloat = PlayerPrefs.GetFloat(Sounds);
            SoundSlider.value = soundsFloat;
        }

    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(Music, MusicSlider.value);
        PlayerPrefs.SetFloat(Sounds, SoundSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSoundSettings();
        }
    }

    public void updateSound() 
    {


        MusicAudio.volume = MusicSlider.value;

        for (int i=0; i<SoundEffects.Length; i++)
        {
            SoundEffects[i].volume = SoundSlider.value;
        }
    
    }


}
