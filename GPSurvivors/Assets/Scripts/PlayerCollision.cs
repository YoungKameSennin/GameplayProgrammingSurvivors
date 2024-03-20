using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private float damage = 30.0f;
    [SerializeField] private float healBottleAmount = 25.0f;
    // Codes for changing player color
    //private SpriteRenderer playerRenderer;
    //private Color originalColor;

    private void Start()
    {
        //playerRenderer = GetComponent<SpriteRenderer>();
        //originalColor = playerRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy") 
        {
            // Player takes damage
            gameObject.GetComponent<Health>().TakeDamage(damage);

            // Change player's color to red for 0.5 seconds
            //StartCoroutine(FlashRed());
        }

        if (collision.gameObject.tag == "hpBottle") 
        {
            // increase the player's hp
            gameObject.GetComponent<Health>().Heal(healBottleAmount);
            // Distory the hp bottle
            Destroy(collision.gameObject);
        }
    }
    /*
    IEnumerator FlashRed()
    {
        // Change player's color to red
        playerRenderer.color = Color.red;

        // Wait for 0.5 seconds
        yield return new WaitForSeconds(0.5f);

        // Change player's color back to original color
        playerRenderer.color = originalColor;
    }
    */
}
