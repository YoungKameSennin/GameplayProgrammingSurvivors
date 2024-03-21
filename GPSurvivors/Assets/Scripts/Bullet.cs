﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 50.0f;
    public float speed = 8.0f;
    public float rotateSpeed = 200f;//adjust if needed
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
            // let bullet keep track the enemy
            Vector2 direction = (target.position - transform.position).normalized;
            lastDirection = direction;

            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            GetComponent<Rigidbody2D>().angularVelocity = -rotateAmount * rotateSpeed;
            GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = lastDirection * speed;
            CheckIfOutOfCameraBounds();
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

    void CheckIfOutOfCameraBounds()
    {
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1)
        {
            Destroy(gameObject);
        }
    }


}