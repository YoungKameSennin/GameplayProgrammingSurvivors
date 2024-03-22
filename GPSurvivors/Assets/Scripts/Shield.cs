using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private ShieldManager shieldManager;
    public float shieldHealth;


    public void Update()
    {
    }

    public void Initialize(ShieldManager manager, float initialHealth)
    {
        shieldManager = manager;
        shieldHealth = initialHealth;
    }

    // If the shield is hit by an enemy or a bullet, apply damage to the shield.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ApplyDamage(10);
        }
        if (collision.gameObject.tag == "TABullet")
        {
            ApplyDamage(30);
        }
    }

    // Apply damage to the shield.
    private void ApplyDamage(float damage)
    {
        shieldHealth -= damage;
        if (shieldHealth <= 0)
        {
            shieldManager.OnShieldDestroyed();
            Destroy(gameObject);
        }
    }
}

