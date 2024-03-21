using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private ShieldManager shieldManager;
    public float shieldHealth;


    public void Update()
    {
        Debug.Log($"shieldHealth start:{shieldHealth}");
    }
    public void Initialize(ShieldManager manager, float initialHealth)
    {
        shieldManager = manager;
        shieldHealth = initialHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Run");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit the shield, applying damage.");
            ApplyDamage(10);
        }
    }

    private void ApplyDamage(float damage)
    {
        
        shieldHealth -= damage;
        Debug.Log($"Shield damaged. Current health: {shieldHealth}");

        if (shieldHealth <= 0)
        {
            Debug.Log("Shield destroyed.");
            shieldManager.OnShieldDestroyed();
            Destroy(gameObject); 
        }
    }
}

