using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject shieldPrefab; 
    private GameObject currentShield; 
    public float shieldHealth = 100f; 

    void Update()
    {
        if (PlayerStatsManager.Instance != null && PlayerStatsManager.Instance.playerPosition != null)
        {
            if (currentShield != null)
            {
               
                currentShield.transform.position = PlayerStatsManager.Instance.playerPosition.position;
            }
        }
        else
        {
            Debug.LogWarning("Player position is null.");
            
            if (currentShield != null) DestroyShield();
        }
    }

    public void ActivateShield()
    {
        if (currentShield == null)
        {
            currentShield = Instantiate(shieldPrefab, PlayerStatsManager.Instance.playerPosition.position, Quaternion.identity);
            Shield shieldScript = currentShield.GetComponent<Shield>(); 
            if (shieldScript != null)
            {
                shieldScript.Initialize(this);
            }
        }
    }

    public void DestroyShield()
    {
        if (currentShield != null)
        {
            Destroy(currentShield);
            currentShield = null;
        }
    }

    public void ApplyDamageToShield(float damage)
    {
        
        shieldHealth -= damage;
        Debug.Log($"Shield damaged. Current health: {shieldHealth}");

        if (shieldHealth <= 0)
        {
            Debug.Log("Shield destroyed.");
            DestroyShield();
        }
    }
}