using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        if(maxHealth <= 0)
        {
            maxHealth = 100;
        }

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void ReceiveDamage(int damage)
    {
        currentHealth -= damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            //ReceiveDamage(20);
        }
    }
}
