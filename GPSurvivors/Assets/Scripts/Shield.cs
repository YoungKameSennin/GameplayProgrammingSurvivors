using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
 
    public float health;

    void Update()
    {

        if (PlayerStatsManager.Instance != null && PlayerStatsManager.Instance.playerPosition != null)

        {
            transform.position = PlayerStatsManager.Instance.playerPosition.position;
        }
        else
        {
            Debug.LogWarning("Player position is null, deactivating shield.");
            DeactivateShield();
        }


    }
    public void ActivateShield()
    {
        health = PlayerStatsManager.Instance.ShieldHealth;

        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIt running");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit the shield, applying damage.");
            ApplyDamageToShield(10);
        }
    }
    public void DeactivateShield()
    {
      
        gameObject.SetActive(false);
    }

    public void ApplyDamageToShield(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DeactivateShield();
        }
    }

}
