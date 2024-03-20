using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject shieldPrefab; 
    private GameObject currentShield; 
    public float shieldHealth;

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
            
            if (currentShield != null)
            {
                Destroy(currentShield);
            }
        }
    }

    public void ActivateShield()
    {
        if (currentShield == null)
        {
            currentShield = Instantiate(shieldPrefab, PlayerStatsManager.Instance.playerPosition.position, Quaternion.identity);
            Shield shieldScript = currentShield.GetComponent<Shield>();
            shieldHealth = PlayerStatsManager.Instance.ShieldHealth;
            
            if (shieldScript == null)
            {
                
                shieldScript.Initialize(this, shieldHealth);
            }
        }
    }


}