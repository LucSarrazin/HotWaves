using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWall1 : MonoBehaviour
{

    public Player playerScript;
    public Enemy1[] enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy[0].HitWallLeft = true;
            enemy[1].HitWallLeft = true;
            enemy[2].HitWallLeft = true;
            enemy[0].HitWallRight = false;
            enemy[1].HitWallRight = false;
            enemy[2].HitWallRight = false;
        }
        
        
        
    }

}
