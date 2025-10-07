using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float cooldownMin = 1;
    public float cooldownMax = 3;

    public float xOffsetMin = 2;
    public float xOffsetMax = 4;

    public GameObject obstaclePrefab;

    float lastSpawnTime = 1;
    Vector3 positionOffset = new();
    Vector2 scale;

    void Start()
    {
        positionOffset.y = obstaclePrefab.transform.position.y;
        positionOffset.x = Random.Range(xOffsetMin, xOffsetMax) + 9;

        scale.x = 1;
        scale.y = 1;
    }

    void Update()
    {
        if (lastSpawnTime <= 0)
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
        lastSpawnTime -= Time.deltaTime;
    }
}
