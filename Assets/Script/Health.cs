using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float speed;
    
    private Player playerScript;
    public bool alreadyRecup = false;
    public AudioSource healthTake;
    
   // private int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        healthTake = GameObject.FindGameObjectWithTag("health").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    private void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (alreadyRecup == false && playerScript.life < 5)
            {
                alreadyRecup = true;
                healthTake.Play();
                playerScript.life++;
            }
            Destroy(gameObject,1f);
        }
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
        
    }

}
