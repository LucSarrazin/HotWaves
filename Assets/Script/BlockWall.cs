using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWall : MonoBehaviour
{

    public Player playerScript;
    
    
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
        // Player touch right or left wall with his trigger
        if (other == playerScript.TriggerRight)
        {
            playerScript.HitWallRight = true;
            
        }
        else
        {
            playerScript.HitWallRight = false;
        }
        if (other == playerScript.TriggerLeft)
        {
            playerScript.HitWallLeft = true;
        }
        else
        {
            playerScript.HitWallLeft = false;
        }
        
        
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Player don't touch right or left wall with his trigger
        if(other == playerScript.TriggerRight)
        {
            playerScript.HitWallRight = false;
        }
        if(other == playerScript.TriggerLeft)
        {
            playerScript.HitWallLeft = false;
        }
        
    }
}
