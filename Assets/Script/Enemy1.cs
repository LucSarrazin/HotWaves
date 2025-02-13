using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{

    public int life;
    public bool IsBoss;
    public Collider2D Collider;
    public Collider2D wallCollider;
    public float speed;

    public float TimeDelay;
    public float RepeatDelay;
    
    

    public ParticleSystem explosion;
    private Player playerScript;
    public Shoot bullet;
    public GameObject Bullet;

    public Slider VieSlider;
    public GameObject SliderLife;
    
    
    public bool HitWallRight;
    public bool HitWallLeft;

    public AudioSource damaged;
    public AudioSource explode;

   // private int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        wallCollider = GameObject.FindGameObjectWithTag("WallGauche").GetComponent<Collider2D>();
        damaged = GameObject.FindGameObjectWithTag("Hurt").GetComponent<AudioSource>();
        explode = GameObject.FindGameObjectWithTag("Explosion").GetComponent<AudioSource>();
        speed = 3;
        
        
InvokeRepeating("BulletLaunch", TimeDelay, RepeatDelay);
        // layerMask = Physics2D.AllLayers;
    }

    private void Update()
    {
        if (playerScript.StartGame == false)
        {
            speed = 3;
        }
      
        
       // Physics2D.IsTouchingLayers(Collider, layerMask);
       VieSlider.value = life;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            if (HitWallRight == false)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        
            if (HitWallLeft == false)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            
        
        
        
        
        
        
        
        
        
       
       
    }

    void BulletLaunch()
    {
        Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        
        
       
        

        if (other.gameObject.CompareTag("Bullet"))
        {
            damaged.Play();
            life--;
            SliderLife.SetActive(true);
            if (life <= 0)
            {
                explode.Play();
                playerScript.points++;
                playerScript.points++;
                playerScript.points++;
                Instantiate(explosion, transform.position, new Quaternion(0, 180, 0, 0)); 
                Destroy(gameObject);
                print("Touch Bullet");
            }

            


        }

        if (other.gameObject.CompareTag("WallDroit"))
        {
           
            HitWallRight = true;
            HitWallLeft = false;
        }
        if (other.gameObject.CompareTag("WallGauche"))
        {
            HitWallLeft = true;
            HitWallRight = false;
        }
        if (other.gameObject.CompareTag("Destroy"))
        {
            playerScript.life--;
            Destroy(gameObject);
            print("Touch Limit");
        }

      
        
    }
    

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("WallDroit"))
        {
            
        }
        if (other.gameObject.CompareTag("WallGauche"))
        {
            
        }
      //  if (other.gameObject.CompareTag("Enemy"))
        //{
          //  SliderLife.SetActive(false);
      //  }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Physics2D.IgnoreCollision(wallCollider,Collider, true);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        Physics2D.IgnoreCollision(wallCollider,Collider, false);
    }
    
}
