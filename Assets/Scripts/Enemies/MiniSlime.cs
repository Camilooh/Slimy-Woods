using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniSlime : MonoBehaviour
{
    
    public PlayerMovement player;
    public float speed = 2.0f;
    //Reference for Patrol max points
    public Transform pointA;
    public Transform pointB;

    private Transform target;
    public bool isDestroyed = false;
    public AudioSource MinislimeSounds;
    public AudioClip Walking, Die;
    bool canDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        MinislimeSounds.PlayOneShot(Walking);

        target = pointA;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(isDestroyed);
        Vector3 direction = target.position - transform.position;
        transform.position += direction * speed * Time.deltaTime;
        direction.Normalize();
        if (isDestroyed)
        {
            Debug.Log("isdestroyed");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PointA")
        {
            target = pointB;
           // Debug.Log("Go to PointB");
        }
        if(collision.transform.tag == "PointB")
        {
            target = pointA;
        }

        if(collision.transform.tag == "Player" && player.JumpAttack)
        {
            canDamage = true;
            MinislimeSounds.Stop();
            MinislimeSounds.PlayOneShot(Die);
           Destroy(this.gameObject,0.25f);
        }
        if(collision.transform.tag == "Player")
        {
            if (!canDamage)
            {
                DealDamage();
                Debug.Log("Tocando player");
            }
           
        }
        if(collision.transform.tag == "PlayerProjectile")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        
    }

  void DealDamage()
    {
        player.playerHearts--;
        player.ReceiveDamage();
    }
}
