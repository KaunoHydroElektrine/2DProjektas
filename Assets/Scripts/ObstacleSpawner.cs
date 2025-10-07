using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{
    //public List<GameObject> obstaclePrefabs; // zdz sukurk skirtingai atrodanciu kliuciu

    public float cooldownMin = 1;
    public float cooldownMax = 3;

    public float safeSize = 1.5f;

    public GameObject obstaclePrefab;

    float safeLocation;
    float lastSpawnTime = 1;
    Vector2 vector = new Vector2(1, 1);
    Vector3 positionOffset = new();
    List<GameObject> childs = new();

    void Start()
    {
        positionOffset.x = 9;


        for(int i=0; i< obstaclePrefab.transform.childCount; i++)
        {
            childs.Add(obstaclePrefab.transform.GetChild(i).gameObject);
        }
    }
    
    void Update()
    {
        if(lastSpawnTime<= 0)
        {
            safeLocation = Random.Range(-3.5f, 4f);

            childs[0].transform.localScale = vector * (positionOffset.y + safeSize / 2);
            childs[1].transform.localScale = vector * (positionOffset.y - safeSize / 2);

            positionOffset.y = 4f -    childs[0].transform.localScale.y / 2;
            positionOffset.y = 3.5f + childs[1].transform.localScale.y / 2;

            Instantiate(obstaclePrefab, positionOffset, Quaternion.identity);

            positionOffset.y = 0; // myliu gyvenima

            lastSpawnTime = Random.Range(cooldownMin, cooldownMax);
        }

        lastSpawnTime = lastSpawnTime - Time.deltaTime * Random.Range(1f, 1.5f);

        /*if (lastSpawnTime <= 0)
        {
            scale.y = Random.Range(1, 3);
            if(positionOffset.y > 0)
            {
                positionOffset.y = 4- scale.y / 2 +1;
            }
            else
            {
                positionOffset.y = -3.5f + scale.y / 2 - 1;
            }
            obstaclePrefab.transform.localScale = scale;
            Instantiate(obstaclePrefab, positionOffset, Quaternion.identity);
            lastSpawnTime = Random.Range(cooldownMin, cooldownMax);
        }
        lastSpawnTime -= Time.deltaTime;*/
    }
}
