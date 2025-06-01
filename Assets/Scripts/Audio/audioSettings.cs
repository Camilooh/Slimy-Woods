using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSettings : MonoBehaviour
{
    public static readonly string Music = "Music";
    public static readonly string Sounds = "Sounds";
    private float musicFloat, soundsFloat;

    public AudioSource MusicAudio;
    public AudioSource[] SoundEffects;
    bool isMuted = false;
    // Start is called before the first frame update
    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
      

        musicFloat = PlayerPrefs.GetFloat(Music);
        soundsFloat = PlayerPrefs.GetFloat(Sounds);
        MusicAudio.volume = musicFloat;

        for (int i = 0; i < SoundEffects.Length; i++)
        {
            SoundEffects[i].volume = soundsFloat;
        }
    }

    private void Update()
    {
      /*if(Time.timeScale == 0)
        {
            MusicAudio.mute = true;
            for (int i = 0; i < SoundEffects.Length; i++)
            {

                SoundEffects[i].mute = true;

            }
        }
        else
        {
            MusicAudio.mute = false;
            for (int i = 0; i < SoundEffects.Length; i++)
            {
                SoundEffects[i].mute = false;
            }
        }*/
    }
    public void muteallSounds()
    {
        
        isMuted = !isMuted;
        if (isMuted)
        {
            MusicAudio.mute = true;
            for (int i = 0; i < SoundEffects.Length; i++)
            {

                SoundEffects[i].mute = true;

            }
        }
        else
        {
            MusicAudio.mute = false;
            for (int i = 0; i < SoundEffects.Length; i++)
            {
                SoundEffects[i].mute = false;
            }
        }

    }
}
