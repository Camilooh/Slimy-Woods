using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    public UIMAnager UIGem;
    public AudioSource gemSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            UIGem.counter++;
            gemSound.Play();
            Destroy(this.gameObject,0.2f);
        }
    }
}
