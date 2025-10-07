using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementScript : MonoBehaviour
{
    public float speed = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;

        if(transform.position.x <-10)
        {
            Destroy(gameObject);
        }
    }
}
