using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private float damage = 30.0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy") {
            gameObject.GetComponent<Health>().TakeDamage(damage);
        }

        if (collision.gameObject.tag == "Gem") 
        {
            // Destroy the itemPrefab
            Destroy(collision.gameObject);
        }
    }
}
