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

    void Awake()
    {
        player = GameObject.Find("Player");
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
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsHit", true);
            StartCoroutine(HitCooldown());
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
}
