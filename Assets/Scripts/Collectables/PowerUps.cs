using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public PlayerMovement player;
    public UIMAnager uiman;
    public AudioSource PowerAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            player.powerUps+=5;
            uiman.powerup+=5;
            PowerAudio.Play();
            Destroy(this.gameObject, 0.3f);
        }
    }
}
