using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Enemy EnemyPrefab;
    public float TimeToSpawn;
    public Transform[] Points;
    int count=0;
    public Text countText;


    private float timer;
    void Start()
    {
        timer = TimeToSpawn/2;
        count = 0;
        countText.text = "Enemy: " + count.ToString();
    }

    void Update()
    {
        timer -= Time.deltaTime/2;

        if(timer <= 0)
        {
            Enemy enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            enemy.Points = Points;
            timer = TimeToSpawn;
            count++;
            countText.text= "Enemy: " + count.ToString();
        }
    }
}
