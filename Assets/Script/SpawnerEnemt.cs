using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerEnemt : MonoBehaviour
{

    public GameObject[] enemy;
    public GameObject[] boss;
    public GameObject Medic;
    public Player player;

    public float TimeDelay;
    public float RepeatRate;
    
    public float BossTimeDelay;
    public float BossRepeatRate;
    
    public float MedicTimeDelay;
    public float MedicRepeatRate;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SpawnStart()
    {
        InvokeRepeating("Spawn",TimeDelay,RepeatRate); 
        InvokeRepeating("SpawnBoss",BossTimeDelay,BossRepeatRate);
        InvokeRepeating("SpawnMedic",MedicTimeDelay,MedicRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if (player.StartGame == false)
        {
            RepeatRate = 1;
            CancelInvoke();
        }
    }

    public void Spawn()
    {
        Instantiate(enemy[Random.Range(0, 3)], new Vector3(Random.Range(-10,10), Random.Range(6,15)), quaternion.identity);
        RepeatRate =  RepeatRate - 0.10f;
    }

    public void SpawnBoss()
    {
        Instantiate(boss[Random.Range(0, 3)], new Vector3(Random.Range(-8,-7), 3.54f), quaternion.identity);
        BossRepeatRate =  BossRepeatRate - 10f;
    }
    public void SpawnMedic()
    {
        Instantiate(Medic, new Vector3(Random.Range(-10,10), Random.Range(6,15)), quaternion.identity);
        MedicRepeatRate =  MedicRepeatRate - 0.10f;
    }
}
