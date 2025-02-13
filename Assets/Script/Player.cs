using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool HitWallRight = false;
    public bool HitWallLeft = false;
    public float speed;

    public float value;
    public float points;
    public float HighScore;
    public float life;
    

    public CircleCollider2D TriggerRight;
    public CircleCollider2D TriggerLeft;
    public BoxCollider2D spawnBullet;
    public GameObject bullet;
    public SpawnerEnemt spawner;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ScoreText2;
    public TextMeshProUGUI ScoreText3;
    public TextMeshProUGUI LifeText;
    public TextMeshProUGUI LifeText2;
    public GameObject ScoreTextObject;
    public GameObject LifeTextObject;
    public TextMeshProUGUI HighScoreText;
    public Enemy[] enemy;
    public Enemy1[] enemy1;

    public float TimeDelay;
    public float RepeatRate;
    
    public bool StartGame;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject button1;
    public GameObject GlobalVolume;
    public GameObject KillRest;

    public AudioSource hurt;
    public AudioSource pistolet;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        
        StartGame = false;
        HighScore = PlayerPrefs.GetFloat("HighScore");
        
    }

    public void GameStart()
    {
        InvokeRepeating("SpeeD", TimeDelay, RepeatRate);
    }

    private void Update()
    {
       
        value = Input.GetAxis("Horizontal");

        ScoreText.text = "Score : " + points;
        ScoreText2.text = "Score : " + points;
        LifeText.text = "Life : " + life;
        LifeText2.text = "Life : " + life;
        HighScoreText.text = "Highscore : " + HighScore;
        ScoreText3.text = "Score : " + points;
        
        if (StartGame == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                pistolet.Play();
                Instantiate(bullet, spawnBullet.transform.position, Quaternion.identity);
            }
        }
       

        if (life <= 0)
        {
            StartGame = false;

        }

        //if (points == 30 || points == 50 || points == 80)
        //{
           // spawner.RepeatRate =  spawner.RepeatRate + 0.10f;
            //enemy[1].speed = enemy[1].speed + 1;
            //enemy[2].speed = enemy[2].speed + 1;
           // enemy[3].speed = enemy[3].speed + 1;
          //  enemy1[1].speed = enemy1[1].speed + 1;
         //   enemy1[2].speed = enemy1[2].speed + 1;
        //    enemy1[3].speed = enemy1[3].speed + 1;
            
       // }
       if (StartGame == false)
       {
           
           PlayerPrefs.GetFloat("Score", points);
           CancelInvoke();
           StopAllCoroutines();
           ScoreTextObject.SetActive(false);
           LifeTextObject.SetActive(false);
           text1.SetActive(true);
           text2.SetActive(true);
           text3.SetActive(true);
           button1.SetActive(true);
           GlobalVolume.SetActive(true);
           KillRest.SetActive(true);


       }

       if (points > HighScore)
       {
           HighScore = points;
           PlayerPrefs.SetFloat("HighScore", HighScore);
       }
            
           
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (StartGame == true)
        {
            if (Input.GetButton("Horizontal") && value > 0 && HitWallRight == false)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetButton("Horizontal") && value < 0 && HitWallLeft == false)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

       
        
    }

    public void GoToTheRight()
    {
        if (HitWallRight == false)
        {
            transform.Translate(Vector3.right * speed * 5 * Time.deltaTime);
        }
    }
    public void GoToTheLeft()
    {
        if (HitWallLeft == false)
        {
            transform.Translate(Vector3.left * speed * 5 * Time.deltaTime);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BlockWall"))
        {
            
        }
        else
        {
            
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            hurt.Play();
            life--;
        }

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            hurt.Play();
            life--;
        }
    
        
    }

    void SpeeD()
    {
        StartCoroutine("IncreaseSpeed");
    }

    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(60);
        enemy[0].speed = enemy[0].speed + 1;
        enemy[1].speed = enemy[1].speed + 1;
        enemy[2].speed = enemy[2].speed + 1;
        enemy1[0].speed = enemy1[0].speed + 1;
        enemy1[1].speed = enemy1[1].speed + 1;
        enemy1[2].speed = enemy1[2].speed + 1;
    }

    
}
