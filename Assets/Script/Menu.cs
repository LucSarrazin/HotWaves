using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Player player;

    public SpawnerEnemt spawner;

    public Background background;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject button1;
    public GameObject GlobalVolume;
    public GameObject KillRest;
    
    public GameObject Score;
    public GameObject Life;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        player.StartGame = true;
        player.GameStart();
        spawner.SpawnStart();
        background.GameStart();
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        button1.SetActive(false);
        Score.SetActive(true);
        Life.SetActive(true);
        GlobalVolume.SetActive(false);
        KillRest.SetActive(false);
        player.points = 0;
        player.life = 3;
        
    }
}
