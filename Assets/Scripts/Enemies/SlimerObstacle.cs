using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimerObstacle : MonoBehaviour
{
    public SlimerPlayerDetector sl;
    public PlayerMovement player;
    public float speed = 2.0f;
    //Reference for Patrol max points
    public Transform pointA;
    public Transform pointB;

    private Transform target;
    public bool isDestroyed = false;

    Animator anim;

    public AudioSource SlimerAudio;
    public AudioClip Walking, ground;

    // Start is called before the first frame update
    void Start()
    {
        target = pointA;
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        if (sl.Player)
        {
            anim.SetBool("PlayerEnter", true);
            Debug.Log("Animacion");
            transform.position += direction * 0 * Time.deltaTime;
            
        }
        else
        {
            Invoke("SlimerMovement", 1.0f);
            Invoke("ResumeWalking", 1.0f);
           // walk.Play();
            
        }
    }
    public void playWalkSound()
    {
        SlimerAudio.PlayOneShot(Walking);
       
    }
    public void playstillSound()
    {
        SlimerAudio.Stop();
        SlimerAudio.PlayOneShot(ground);
    }
       public void SlimerMovement()
    {
        Vector3 direction = target.position - transform.position;
        transform.position += direction * speed * Time.deltaTime;
        direction.Normalize();
        if (isDestroyed)
        {
            //Debug.Log("isdestroyed");
        }
    }
    public void ResumeWalking()
    {
       // anim.SetBool("isWalking", true);
        anim.SetBool("PlayerEnter", false);
       
    }
    public void IdleGround()
    {
        anim.SetBool("Idle", true);
       
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
           // Debug.Log("Go to PointA");
        }

       if(collision.transform.tag == "Player" && sl.Player)
        {
            player.playerHearts--;
            player.ReceiveDamage();
        }

    }
}
