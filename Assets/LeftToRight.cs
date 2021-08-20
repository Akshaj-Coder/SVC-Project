using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftToRight : MonoBehaviour
{

    Vector3 startPos;

    public int EnemySpeed;

    void Start()
    {
        startPos = gameObject.transform.position;

    }


    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * EnemySpeed;



    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            EnemySpeed = -EnemySpeed;
        }

   
    }
}
