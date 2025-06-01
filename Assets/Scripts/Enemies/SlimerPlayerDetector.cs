using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimerPlayerDetector : MonoBehaviour
{
    public bool Player = false;
    public SlimerObstacle slime;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            slime.playstillSound();
            Player = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            slime.playWalkSound();
            Player = false;
        }
    }
}
