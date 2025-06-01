using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    
    public float speed = 5f;
    public float jumpForce = 300.0f;

    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask isGroundLayer;
    public float groundCheckRadius = 0.02f;

    public bool isFalling = false;
    public bool isDead = false;
    public int playerHearts = 4;
    public int powerUps = 0;
    public GameObject Projectile;
    public Transform spawnProjectileRight;
    public Transform spawnProjectileLeft;
    public float projectileSpeed;
    public Projectile ProjectileScript;
    public bool JumpAttack = false;
    public bool WallJump = false;
    public GameObject DeathPanel;
    public AudioSource DeathSound,PlayerSounds;
    public AudioClip jump, damage, shoot,death;
    public UIMAnager uiman;

    // Start is called before the first frame update
    void Start()
    {
       
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (groundCheck == null)
        {
            GameObject obj = new GameObject();
            obj.transform.SetParent(gameObject.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.name = "GroundCheck";
            groundCheck = obj.transform;
        }

      
        DeathPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sr.flipX);
        if (!isDead)
        {
            PlayerMove();
            PLayerJump();
            CheckFalling();
            playerShoot();
        }
        else
        {
            anim.Play("Dead");
        }
        if(playerHearts == 0)
        {
            
            isDead = true;
            Invoke("ShowDeathPanel", 1f);
            Invoke("deathSound", 0.1f);

        }

        
    }
    void deathSound()
    {
        if(!PlayerSounds.isPlaying)
        PlayerSounds.PlayOneShot(death);
        
    }
    void ShowDeathPanel()
    {
        DeathSound.Play();
        DeathPanel.SetActive(true);
        Time.timeScale = 0;
    }
    void PlayerMove()
    {
      
        
        float hInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveDir = new Vector2(hInput * speed, rb.velocity.y);
        rb.velocity = moveDir;

        if(hInput == 1)
        {
            
            sr.flipX = false;
        }
        if(hInput == -1)
        {
           
            sr.flipX = true;
        }
        if(hInput == 0)
        {
            anim.SetBool("Iddle", true);
        }
        else
        {
            anim.SetBool("Iddle", false);
        }

        anim.SetFloat("isWalking", Mathf.Abs(hInput));
      
    }
    void playerShoot()
    {
        if (Input.GetButtonDown("Fire1") && powerUps > 0)
        {
            PlayerSounds.PlayOneShot(shoot);
            powerUps--;
            uiman.powerup--;
            //Debug.Log(sr.flipX);
            if (!sr.flipX)
            {
               Projectile CuProjectile= Instantiate(ProjectileScript, spawnProjectileRight.position, spawnProjectileRight.rotation);
                CuProjectile.speed = projectileSpeed;
            }
            else
            {
                Projectile CuProjectile = Instantiate(ProjectileScript, spawnProjectileLeft.position, spawnProjectileLeft.rotation);
                CuProjectile.speed = -projectileSpeed;
            }
        }
    }

    void PLayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            PlayerSounds.PlayOneShot(jump);
        }
        anim.SetBool("isJumping", !isGrounded);

        if(Input.GetButtonDown("Jump") && WallJump)
        {
            PlayerSounds.PlayOneShot(jump);
            rb.AddForce(Vector2.up * jumpForce);
            Debug.Log("walljump");
        }
    }

    void CheckFalling()
    {
        if (!isGrounded && Input.GetKey(KeyCode.Q) && !sr.flipX)
        {
            Debug.Log("Jump Attack");
            rb.gravityScale = 5;
            rb.AddForce(Vector2.right * 50);
            JumpAttack = true;

        }
        if (!isGrounded && Input.GetKey(KeyCode.Q) && sr.flipX)
        {
            Debug.Log("Jump Attack");
            rb.gravityScale = 5;
            rb.AddForce(Vector2.left * 50);
            JumpAttack = true;
        }

        if (isGrounded)
        {
            rb.gravityScale = 1;
            JumpAttack = false;
        }


        if (rb.velocity.y < 0)
        {
           // Debug.Log("Falling");
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
    }

    public void ReceiveDamage()
    {
        anim.SetBool("isDamaged", true);
        Invoke("stopDamageAnim", 1f);
        PlayerSounds.PlayOneShot(damage);

    }

    void stopDamageAnim()
    {
        PlayerSounds.Stop();
        anim.SetBool("isDamaged", false);
    }
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Dead")
        {

            anim.Play("Dead");
            playerHearts = 0;
           
            Debug.Log("PlayerDies");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            WallJump = true;
            Debug.Log(WallJump);
        }
        
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            WallJump = false;

        }
    }
}
