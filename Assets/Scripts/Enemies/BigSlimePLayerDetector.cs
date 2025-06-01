using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSlimePLayerDetector : MonoBehaviour
{
    public bool playerDetected = false;
    
    // Start is called before the first frame update
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            
            playerDetected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerDetected = false;
        }
    }
}
