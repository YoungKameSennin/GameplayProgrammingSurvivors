using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public float curHealth = 100.0f;
    [SerializeField] public float maxHealth = 100.0f;
    [SerializeField] private Slider healthBar;
    
    [SerializeField] private GameObject itemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
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

    void Die()
    {
        if (itemPrefab != null)
        {
            GameObject item = Instantiate(itemPrefab, transform.position, Quaternion.identity);

            item.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); 

            // Ignore collision between the spawned itemPrefab and all GameObjects tagged as "Enemy"
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Physics2D.IgnoreCollision(item.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>(), true);
            }

            // Access the Rigidbody component of the instantiated item, if it exists
            Rigidbody2D itemRigidbody = item.GetComponent<Rigidbody2D>();

            if (itemRigidbody != null)
            {
                // Set the gravity scale of the Rigidbody to 0 so that the item won't move
                itemRigidbody.gravityScale = 0f;
            }
        }
        if(gameObject.tag == "Player")
        {
            // Stop the time
            Time.timeScale = 0f;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else{
            Destroy(gameObject);
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
            else{
                Destroy(gameObject);
            }
        }
    }
}
