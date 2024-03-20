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

    // Start is called before the first frame update
    void Start()
    {
        // Set the player's health to max
        curHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {   
        if (this.scrollingText)
        {
            this.ShowScrollingText(damage.ToString());
        }

        if (curHealth - damage <= 0)
        {
            curHealth = 0;
            // Die, drop item
            Die();
        }
        else
        {
            curHealth -= damage;
        }
    }

    public void Heal(float healAmount)
    {
        if (curHealth + healAmount >= maxHealth)
        {
            curHealth = maxHealth;
        }
        else
        {
            curHealth += healAmount;
        }
    }

    private void Die()
    {
        if (gemPrefab != null)
        {
            // drop gem
            GameObject gemSpawned = Instantiate(gemPrefab, transform.position, Quaternion.identity);

            Rigidbody2D gemRigidbody = gemSpawned.GetComponent<Rigidbody2D>();
            if (gemRigidbody != null)
            {
                gemRigidbody.gravityScale = 0f;
            }

            // Drop hp bottle
            // Spawn HP bottle with a chance
            int randomChance = Random.Range(0, hpBottleChance);
            if (randomChance == 0)
            {
                GameObject hpBottleSpawned = Instantiate(hpBottlePrefab, transform.position + Vector3.up, Quaternion.identity);
                // Make the gravity of the hp bottle to 0, so that it won't move
                Rigidbody2D hpBottleRigidbody = hpBottleSpawned.GetComponent<Rigidbody2D>();
                if (hpBottleRigidbody != null)
                {
                    hpBottleRigidbody.gravityScale = 0f;
                }
            }
        }

        if (gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void ShowScrollingText(string message)
    {
        var scrollingText = Instantiate(this.scrollingText, this.transform.position, Quaternion.identity);
        scrollingText.GetComponent<TextMesh>().text = message;
    }
    

    // Update is called once per frame
    void Update()
    {
        healthBar.value = curHealth / maxHealth;
        if (curHealth <= 0)
        {
            if (gameObject.tag == "Player")
            {
                // Stop the time
                Time.timeScale = 0f;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
