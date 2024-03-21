using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum UpgradeOption
{
    IncreaseBullets,
    IncreaseShieldHealth,
    IncreaseIceBall,
    IncreaseMarryGoRound,
    IncreaseAPbullet
    // 可以添加更多技能提升选项
}

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


    [SerializeField] private float experiencePerGem = 8.0f;
    [SerializeField] private float experiencePerCode = 80.0f;
    public UIExperienceBar uiExperienceBar;

    public int iceballCount = 0;

    public int MarryGoRoundCount = 0;
    public int APbulletCount = 0;


    public TMP_Text textMesh1;
    public TMP_Text textMesh2;
    public TMP_Text textMesh3;
    List<UpgradeOption> options;
    public Transform LevelUpUI;


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
        if (collision.gameObject.CompareTag("Code"))
        {
            Destroy(collision.gameObject);
            AddExperience(experiencePerCode);
        }
    }

    public void AddExperience(float amount)
    {
        currentExperience += amount;

        if (currentExperience >= maxExperience)
        {
            LevelUp();
            currentExperience -= maxExperience;
            maxExperience *= 1.3f;
        }

        uiExperienceBar.UpdateExperienceUI(currentExperience, maxExperience);
    }

    public void LevelUp()
    {
        level++;
        Time.timeScale = 0f;
        LevelUpUI.gameObject.SetActive(true);
        options = GetRandomUpgradeOptions();
        switch (options[0])
        {
            case UpgradeOption.IncreaseBullets:
                textMesh1.text = "Fire Ball + 1";
                break;
            case UpgradeOption.IncreaseShieldHealth:
                textMesh1.text = "Get Shield Enhance";
                break;
            case UpgradeOption.IncreaseIceBall:
                textMesh1.text = "Ice Ball + 1";
                break;
            case UpgradeOption.IncreaseMarryGoRound:
                textMesh1.text = "Marry Go Round + 2";
                break;
            case UpgradeOption.IncreaseAPbullet:
                textMesh1.text = "AP Bullet + 1";
                break;
        }

        switch (options[1])
        {
            case UpgradeOption.IncreaseBullets:
                textMesh2.text = "Fire Ball + 1";
                break;
            case UpgradeOption.IncreaseShieldHealth:
                textMesh2.text = "Get Shield Enhance";
                break;
            case UpgradeOption.IncreaseIceBall:
                textMesh2.text = "Ice Ball + 1";
                break;
            case UpgradeOption.IncreaseMarryGoRound:
                textMesh2.text = "Marry Go Round + 2";
                break;
            case UpgradeOption.IncreaseAPbullet:
                textMesh2.text = "AP Bullet + 1";
                break;
        }

        switch (options[2])
        {
            case UpgradeOption.IncreaseBullets:
                textMesh3.text = "Fire Ball + 1";
                break;
            case UpgradeOption.IncreaseShieldHealth:
                textMesh3.text = "Get Shield Enhance";
                break;
            case UpgradeOption.IncreaseIceBall:
                textMesh3.text = "Ice Ball + 1";
                break;
            case UpgradeOption.IncreaseMarryGoRound:
                textMesh3.text = "Marry Go Round + 2";
                break;
            case UpgradeOption.IncreaseAPbullet:
                textMesh3.text = "AP Bullet + 1";
                break;
        }

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

    public void OnClickButton1()
    {
        ApplyUpgrade(options[0]);
        Time.timeScale = 1f;
        LevelUpUI.gameObject.SetActive(false);
    }

    public void OnClickButton2()
    {
        ApplyUpgrade(options[1]);
        Time.timeScale = 1f;
        LevelUpUI.gameObject.SetActive(false);
    }

    public void OnClickButton3()
    {
        ApplyUpgrade(options[2]);
        Time.timeScale = 1f;
        LevelUpUI.gameObject.SetActive(false);
    }

}


