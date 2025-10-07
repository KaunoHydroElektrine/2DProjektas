using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{
    public float cooldownMin = 1;
    public float cooldownMax = 3;

    public float safeSize = 1.5f;

    public GameObject obstaclePrefab;

    float safeLocation;
    float lastSpawnTime = 1;
    Vector3 positionOffset = new();
    Transform[] transforms;

    void Start()
    {
        positionOffset.x = 9;



        foreach (Transform t in obstaclePrefab.transform)
        {
            transforms.Append<Transform>(t);
        }
    }
    
    void Update()
    {
        if(lastSpawnTime<= 0)
        {
            safeLocation = Random.Range(-3.5f, 4f);

            transforms[0].localScale = Vector3.down * (positionOffset.y + safeSize / 2);
            transforms[1].localScale = Vector3.up * (positionOffset.y - safeSize / 2);

            positionOffset.y = 4f - transforms[0].localScale.y / 2;
            positionOffset.y = 3.5f + transforms[1].localScale.y / 2;

            Instantiate(obstaclePrefab, positionOffset, Quaternion.identity);

            lastSpawnTime = lastSpawnTime-Time.deltaTime * Random.Range(1f, 1.5f);
        }


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
