using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    AudioSource winsound;
    public GameObject WinPanel;
    public audioSettings background;
    // Start is called before the first frame update
    void Start()
    {
        winsound = GetComponent<AudioSource>();
        WinPanel.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            WinPanel.SetActive(true);
            background.MusicAudio.Stop();
            winsound.Play();

        }
    }
}
