using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSlime : MonoBehaviour
{
    Animator anim;
    public BigSlimePLayerDetector bs;
    public PlayerMovement player;
    public float speed = 2.0f;
    //Reference for Patrol max points
    public Transform pointA;
    public Transform pointB;
    public Transform playerTransform;

    
    private Transform target;
    public bool isDestroyed = false;
    public AudioSource BigSlimeSounds;
    public AudioClip Walking, splash;
    bool isTouchingPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = pointA;
        BigSlimeSounds.PlayOneShot(Walking);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.position += direction * speed * Time.deltaTime;
        direction.Normalize();
        if (isDestroyed)
        {
           // Debug.Log("isdestroyed");
        }

        if (bs.playerDetected)
        {
            anim.SetBool("Follows", true);
            target = playerTransform;
           // Debug.Log("Set Target to Player");
            speed = 1.0f;

        }
       
      
    }

    void DealDamage()
    {
        player.playerHearts--;
        player.ReceiveDamage();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PointA")
        {
            target = pointB;
            // Debug.Log("Go to PointB");
        }
        if (collision.transform.tag == "PointB")
        {
            target = pointA;
        }

        if(collision.transform.tag == "Player")
        {
            DealDamage();
        }
    }

}
