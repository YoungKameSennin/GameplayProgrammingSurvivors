using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager Instance;

    public int level = 1;
    public int bulletsPerShoot = 1;

    //public float ShieldTime = 20f;
    public float ShieldHealth = 50;
    public Transform playerPosition;
    public ShieldManager shieldManager;

    public float health = 100;
    public float shootSpeed = 1.0f;

    public float currentExperience = 0;
    public float maxExperience = 50;

    private float experiencePerGem = 30.0f;
    public UIExperienceBar uiExperienceBar;

    public int iceballCount = 0;

    public int MarryGoRoundCount = 0;
    public int APbulletCount = 0;



    public enum UpgradeOption
    {
        IncreaseBullets,
        IncreaseShieldHealth,
        IncreaseIceBall,
        IncreaseMarryGoRound,
        IncreaseAPbullet
        // 可以添加更多技能提升选项
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        shieldManager = GetComponent<ShieldManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            AddExperience(experiencePerGem);
        }
    }

    public void AddExperience(float amount)
    {
        currentExperience += amount;

        if (currentExperience >= maxExperience)
        {
            LevelUp();
            currentExperience -= maxExperience;
            maxExperience *= 1.1f; 
        }

        uiExperienceBar.UpdateExperienceUI(currentExperience, maxExperience);
    }

    public void LevelUp()
    {
        level++;
        
        List<UpgradeOption> options = GetRandomUpgradeOptions();
        
        ApplyUpgrade(options[0]);
    }

    List<UpgradeOption> GetRandomUpgradeOptions()
    {
        List<UpgradeOption> allOptions = new List<UpgradeOption>()
        {
            UpgradeOption.IncreaseBullets,
            UpgradeOption.IncreaseShieldHealth,
            UpgradeOption.IncreaseIceBall,
            UpgradeOption.IncreaseMarryGoRound,
            UpgradeOption.IncreaseAPbullet
        };

        List<UpgradeOption> chosenOptions = new List<UpgradeOption>();
        for (int i = 0; i < 3; i++) // 随机选择3个不同的选项
        {
            int randomIndex = Random.Range(0, allOptions.Count);
            chosenOptions.Add(allOptions[randomIndex]);
            allOptions.RemoveAt(randomIndex); 
        }
        return chosenOptions;
    }

    void ApplyUpgrade(UpgradeOption option)
    {
        switch (option)
        {
            case UpgradeOption.IncreaseBullets:
                bulletsPerShoot++;
                break;
            case UpgradeOption.IncreaseShieldHealth:
                ShieldHealth += 20f;
                shieldManager.ActivateShield();
                break;
            case UpgradeOption.IncreaseIceBall:
                iceballCount += 1;
                break;
            case UpgradeOption.IncreaseMarryGoRound:
                MarryGoRoundCount += 2;
                FindObjectOfType<MerryGoRound>().UpdateBullets();
                break;
            case UpgradeOption.IncreaseAPbullet:
                Debug.Log("AP!!!!!");
                APbulletCount += 1;
                break;

        }
    }








   
}


