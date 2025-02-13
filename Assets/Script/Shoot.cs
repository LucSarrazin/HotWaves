using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed;
    private Player playerScript;
    public Enemy enemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    transform.Translate(Vector3.up * speed * Time.deltaTime);    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
    //        if (enemy.life == 0)
     //       {
      //          playerScript.points++;
       //         Instantiate(enemy.explosion, transform.position, new Quaternion(0, 180, 0, 0)); 
        //        Destroy(enemy.gameObject);
         //       print("Touch Bullet");
          //  }
           // enemy.life--;
             Destroy(gameObject);
             
        }

        if (other.gameObject.CompareTag("DestroyBullet"))
        {
            Destroy(gameObject);
        }

       
        
    }
 
    
}
