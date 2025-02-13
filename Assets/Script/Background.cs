using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Player player;
    public string[] color;

    public float time = 0;

    public float repeatRate = 5;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void GameStart()
    {
        InvokeRepeating("Change",time, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.StartGame == false)
        {
            CancelInvoke();
            StopAllCoroutines();
        }
    }

    void Change()
    {
        StartCoroutine(changeColor());
    }

    IEnumerator changeColor()
    {
        Color newcolor = new Color(Random.value, Random.value, Random.value);
        gameObject.GetComponent<SpriteRenderer>().material.color = newcolor;
        yield return new WaitForSeconds(25);
    }
}
