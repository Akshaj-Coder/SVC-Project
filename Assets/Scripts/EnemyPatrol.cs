using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private bool flip = false;

    public SpriteRenderer sr;

    public int speed;


    void Start()
    {
        
    }

    void Update()
    {

        if (flip == true)
        {
            sr.flipX = true;
        }

        else
        {
            sr.flipX = false;
        }

    } 


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EdgeDetection")
        {
            flip = true;
            transform.Translate(speed, 0, 0);

        }

        else if (col.gameObject.tag == "RightEdgeDetection")
        {
            flip = false;
            transform.Translate(-speed, 0, 0);
        }
    }
}

