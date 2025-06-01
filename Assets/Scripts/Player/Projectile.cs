using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime;
    [HideInInspector]
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        if (lifeTime <= 0)
        {
            lifeTime = 2.0f;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(this.gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Level")
        {
            Destroy(this.gameObject);
            Debug.Log("colliding");
        }
        if(collision.gameObject.tag == "BigSlime")
        {
            collision.GetComponent<Health>().ReceiveDamage(1);
            Debug.Log(collision.name);
        }
    }


}