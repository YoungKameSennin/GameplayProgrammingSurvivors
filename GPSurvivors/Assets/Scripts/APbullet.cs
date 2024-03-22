using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APbullet : MonoBehaviour
{
    [SerializeField] private float damage = 30.0f;
    public float speed = 15f;
    private Transform target;
    private Vector2 lastDirection;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            // Let bullet keep track the enemy.
            Vector2 direction = (target.position - transform.position).normalized;
            lastDirection = direction;

            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = lastDirection * speed;
            CheckIfOutOfCameraBounds();
        }
    }

    // If the bullet hits an enemy, deal damage to the enemy.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        if (collider.gameObject.tag == "Edge")
        {
            Destroy(gameObject);
        }

    }

    // If the bullet is out of camera bounds, destroy the bullet.
    void CheckIfOutOfCameraBounds()
    {
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1)
        {
            Destroy(gameObject);
        }
    }
}