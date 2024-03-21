using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    private GameObject player;
    private Transform playerTransform;

    private float modifiedSpeed;
    private Vector3 movementDirection; 
    
    public Animator animator;

    public SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red;
    public float hitDuration = 0.5f;
    private bool isHit = false;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start() 
    {
        // Ignore collision between the spawned gem and all enemies
        GameObject[] Gems = GameObject.FindGameObjectsWithTag("Gem");
        foreach (GameObject gem in Gems)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), gem.GetComponent<Collider2D>(), true);
        }
    }

    public float GetCurrentSpeed()
    {
        return modifiedSpeed;
    }

    public Vector3 GetMovementDirection()
    {
        return movementDirection;
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }
        playerTransform = player.transform;
        movementDirection = player.transform.position - this.transform.position;
        movementDirection.Normalize();
        gameObject.transform.Translate(movementDirection * Time.deltaTime * speed);

        if(movementDirection.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hpBottle"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>(), true);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsHit", true);
            StartCoroutine(HitCooldown());
        }

        if (collision.gameObject.CompareTag("bullets"))
        {
            StartCoroutine(FlashColor());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider's gameObject belongs to the "attackLayer"
        if (other.gameObject.layer == LayerMask.NameToLayer("attackLayer"))
        {
            StartCoroutine(FlashColor());
        }
        // Check if the collider's gameObject belongs to the "attackLayer" or is a trigger
        if (other.CompareTag("bullets"))
        {
            StartCoroutine(FlashColor());
        }
    }

    private IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(0.05f); 
        animator.SetBool("IsHitCooldown", true);
        yield return new WaitForSeconds(0.5f); 
        animator.SetBool("IsHit", false);
        animator.SetBool("IsHitCooldown", false);
    }

    private IEnumerator FlashColor()
    {
        if (!isHit)
        {
            isHit = true;
            spriteRenderer.color = hitColor;
            yield return new WaitForSeconds(hitDuration);
            spriteRenderer.color = Color.white;
            isHit = false;
        }
    }
}
