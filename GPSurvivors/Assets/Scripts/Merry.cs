using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Merry : MonoBehaviour
{
    public float damage = 15f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            DestroyBullet();
        }
        else if (collision.gameObject.tag == "Edge" || collision.gameObject.tag == "Gem")
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        
        FindObjectOfType<MerryGoRound>().BulletDestroyed(gameObject);
        Destroy(gameObject);
    }
}