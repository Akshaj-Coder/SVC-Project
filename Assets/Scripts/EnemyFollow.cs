using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private const float speed = 3f;

    public Transform target;

    private bool isColliding = false;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EagleVision")
        {
            isColliding = true;
            Debug.Log("Collided!");
        }
    }
}
