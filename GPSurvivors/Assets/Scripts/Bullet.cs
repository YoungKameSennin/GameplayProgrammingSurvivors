﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 50.0f;
    public float speed = 5f;
    public float rotateSpeed = 200f;//adjust if needed
    private Transform target;

    void Start()
    {
        // Ignore collision with player
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>(), true);
        // Ignore collision between the spawned itemPrefab and all GameObjects tagged as "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Gem");
        foreach (GameObject enemy in enemies)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>(), true);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            // let bullet keep track the enemy
            Vector2 direction = (target.position - transform.position).normalized;

            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            GetComponent<Rigidbody2D>().angularVelocity = -rotateAmount * rotateSpeed;
            GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        }
        else
        {
            Debug.LogWarning("Bullet Update method found no target.");
            Destroy(gameObject);
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collision.gameObject is the reference to the collided object
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Edge")
        {
            Destroy(gameObject);
        }

    }


}