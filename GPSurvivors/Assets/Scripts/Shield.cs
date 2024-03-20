using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private ShieldManager shieldManager;

    public void Initialize(ShieldManager manager)
    {
        shieldManager = manager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit the shield, applying damage.");
            if (shieldManager != null) shieldManager.ApplyDamageToShield(10);
        }
    }
}
