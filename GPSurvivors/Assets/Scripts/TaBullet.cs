using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TABullet : MonoBehaviour
{
    public float speed = 10.0f;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the bullet hits an enemy, ignore the collision.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("TA bullet hit");
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(20);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Edge")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }

    }
}