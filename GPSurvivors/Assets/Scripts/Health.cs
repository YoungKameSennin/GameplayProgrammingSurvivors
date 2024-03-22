using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public float curHealth = 100.0f;
    [SerializeField] public float maxHealth = 100.0f;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private GameObject hpBottlePrefab;
    [SerializeField] private int hpBottleChance = 3;
    [SerializeField] private GameObject scrollingText;

    void Start()
    {
        // Set the GameObject's health to max.
        curHealth = maxHealth;
    }

    // Take damage.
    public void TakeDamage(float damage)
    {
        if (this.scrollingText)
        {
            this.ShowScrollingText(damage.ToString(), "red");
        }

        if (curHealth - damage <= 0)
        {
            curHealth = 0;
            Die();
        }
        else
        {
            curHealth -= damage;
        }
    }

    // Heal the GameObject.
    public void Heal(float healAmount)
    {
        this.ShowScrollingText(healAmount.ToString(), "green");
        if (curHealth + healAmount >= maxHealth)
        {
            curHealth = maxHealth;
        }
        else
        {
            curHealth += healAmount;
        }
    }

    // Die when the player's health is 0.
    private void Die()
    {
        if (gemPrefab != null)
        {
            // Drop gem.
            GameObject gemSpawned = Instantiate(gemPrefab, transform.position, Quaternion.identity);

            Rigidbody2D gemRigidbody = gemSpawned.GetComponent<Rigidbody2D>();
            if (gemRigidbody != null)
            {
                gemRigidbody.gravityScale = 0f;
            }

            // Drop hp bottle.
            // Spawn HP bottle with a chance.
            int randomChance = Random.Range(0, hpBottleChance);
            if (randomChance == 0)
            {
                GameObject hpBottleSpawned = Instantiate(hpBottlePrefab, transform.position + Vector3.up, Quaternion.identity);
                // Make the gravity of the hp bottle to 0, so that it won't move.
                Rigidbody2D hpBottleRigidbody = hpBottleSpawned.GetComponent<Rigidbody2D>();
                if (hpBottleRigidbody != null)
                {
                    hpBottleRigidbody.gravityScale = 0f;
                }
            }
        }

        // If the player dies, stop the game.
        if (gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
        }
        else
        {
            Destroy(gameObject);
        }

        // If the enemy is defeated, set the enemy as defeated.
        if (gameObject.name == "TA_temp(Clone)")
        {
            Debug.Log("TA Defeated");
            FindObjectOfType<EnemySpawner>().TADefeated = true;
        }
        else if (gameObject.name == "Prof_temp(Clone)")
        {
            Debug.Log("Prof Defeated");
            FindObjectOfType<EnemySpawner>().ProfDefeated = true;
            Time.timeScale = 0f;
        }


    }

    // Show scrolling text.
    public void ShowScrollingText(string message, string color = "red")
    {
        var scrollingText = Instantiate(this.scrollingText, this.transform.position, Quaternion.identity);
        scrollingText.GetComponent<TextMesh>().text = message;
        if (color == "red")
        {
            scrollingText.GetComponent<TextMesh>().color = Color.red;
        }
        else if (color == "green")
        {
            scrollingText.GetComponent<TextMesh>().color = Color.green;
        }
    }

    void Update()
    {
        healthBar.value = curHealth / maxHealth;
    }
}
