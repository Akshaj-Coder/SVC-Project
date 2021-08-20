using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   [SerializeField] float moveSpeed = 4f;
   
   Rigidbody2D rb;
   BoxCollider2D boxCollider;
   
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (isFacingRight()) 
        {
    	   rb.velocity = new Vector2(moveSpeed, 0f); 
        } else 
        {
           rb.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    
    private bool isFacingRight() 
    {
    	return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }
}
