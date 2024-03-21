using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TABullet : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collision.gameObject is the reference to the collided object
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Health>().TakeDamage(20);
        }
        if (collision.gameObject.tag == "Edge")
        {
            Destroy(gameObject);
        }
        
    }



}