﻿using System.Collections;
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


    public enum UpgradeOption
    {
        IncreaseBullets,
        IncreaseHealth,
        IncreaseShootSpeed,
        IncreaseShieldHealth,
        // 可以添加更多技能提升选项
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
            maxExperience *= 2.8f; 
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
            //UpgradeOption.IncreaseBullets,
            //UpgradeOption.IncreaseHealth,
            UpgradeOption.IncreaseShieldHealth
        };

        List<UpgradeOption> chosenOptions = new List<UpgradeOption>();
        for (int i = 0; i < 1; i++) // 随机选择3个不同的选项
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
            //case UpgradeOption.IncreaseHealth:
                //health += 20;
                //break;
            case UpgradeOption.IncreaseShootSpeed:
                shootSpeed *= 0.9f; 
                break;
            case UpgradeOption.IncreaseShieldHealth:
                ShieldHealth += 20f;
                shieldManager.ActivateShield();
                break;
        }
    }







    //code related to Shield

   
}


