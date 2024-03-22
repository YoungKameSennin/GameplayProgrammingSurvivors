using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject shieldPrefab;
    private GameObject currentShield;
    public float shieldHealth;
    public float rechargeTime = 10f;

    void Update()
    {
        // If the player is alive, move the shield to the player's position.
        if (PlayerStatsManager.Instance != null && PlayerStatsManager.Instance.playerPosition != null)
        {
            if (currentShield != null)
            {

                currentShield.transform.position = PlayerStatsManager.Instance.playerPosition.position;
            }
        }
        else
        {
            if (currentShield != null)
            {
                Destroy(currentShield);
            }
        }
    }

    // Activate the shield.
    public void ActivateShield()
    {
        if (currentShield == null)
        {
            currentShield = Instantiate(shieldPrefab, PlayerStatsManager.Instance.playerPosition.position, Quaternion.identity);
            FindObjectOfType<SoundManager>().PlaySoundEffect("RechargeShield");
            Shield shieldScript = currentShield.GetComponent<Shield>();
            shieldHealth = PlayerStatsManager.Instance.ShieldHealth;
            if (shieldScript != null)
            {

                shieldScript.Initialize(this, shieldHealth);
            }
        }
    }
    public void OnShieldDestroyed()
    {
        if (currentShield != null)
        {
            currentShield = null;
            StartCoroutine(RechargeShield());
        }
    }

    // Recharge the shield after a certain amount of time.
    IEnumerator RechargeShield()
    {
        yield return new WaitForSeconds(rechargeTime);
        ActivateShield();
    }

}