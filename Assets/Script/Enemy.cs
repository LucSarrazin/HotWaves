using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int life;
    public bool IsBoss;
    public Collider2D Collider;
    public float speed;

    public ParticleSystem explosion;
    private Player playerScript;
    public Shoot bullet;

    public Slider VieSlider;
    public GameObject SliderLife;
    
    
    public bool HitWallRight = false;
    public bool HitWallLeft = false;
    
    public CircleCollider2D TriggerRight;
    public CircleCollider2D TriggerLeft;
    
    public AudioSource damaged;
    public AudioSource explode;
   // private int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        damaged = GameObject.FindGameObjectWithTag("Hurt").GetComponent<AudioSource>();
        explode = GameObject.FindGameObjectWithTag("Explosion").GetComponent<AudioSource>();
        //speed = 1;

        // layerMask = Physics2D.AllLayers;
    }

    private void Update()
    {
       // Physics2D.IsTouchingLayers(Collider, layerMask);
       VieSlider.value = life;
       if (playerScript.StartGame == false)
       {
          // speed = 1;
       }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsBoss == true)
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
        
        
        
        
        
        if (IsBoss == false)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        
        
       
       
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            print("Touch other enemy");
        }
        

        if (other.gameObject.CompareTag("Bullet"))
        {
            life--;
            damaged.Play();
            SliderLife.SetActive(true);
            if (life <= 0)
            {
                explode.Play();
                playerScript.points++;
                ParticleSystem Explosion = Instantiate(explosion, transform.position, new Quaternion(0, 180, 0, 0));
                Destroy(explosion,0.1f);
                Destroy(gameObject);
                print("Touch Bullet");
            }

            


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
        if (other.gameObject.CompareTag("Enemy"))
        {
            SliderLife.SetActive(false);
        }
    }
}
