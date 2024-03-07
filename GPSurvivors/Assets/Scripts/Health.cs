using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public float curHealth = 100.0f;
    [SerializeField] public float maxHealth = 100.0f;
    [SerializeField] private Slider healthBar;

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
            // Die
        }
        else {
            curHealth -= damage;
        }
    }

    public void Heal(float healAmount)
    {
        if (curHealth + healAmount >= maxHealth)
        {
            curHealth = maxHealth;
        }
        else {
            curHealth += healAmount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = curHealth / maxHealth;
    }
}
