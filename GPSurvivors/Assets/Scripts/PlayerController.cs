using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    private float modifiedSpeed;
    private Vector3 movementDirection; 
    public Animator animator;

    public Transform GameOverUI;
    public Transform LevelUpUI;
    public Transform GameWinUI;
    // private GameOverUISection gameOverSection;
    private Vector3 originalPosition;
    private Health health;
    public int GemCount = 0;
    private int GemCountLastFrame = 0;

    public PlayerStatsManager playerStatsManager;
    public int LastFrameLevel = 1;
    void Awake()
    {
        transform.position = new Vector3(0, 0, 0);
        health = GetComponent<Health>();

        // gameOverSection = new GameOverUISection(GameOverUI);
        // gameOverSection.SetActive(false);
        // gameOverSection.OnClickRestartButtonAction = OnClickRestartButton;
        originalPosition = transform.position;
        LastFrameLevel = playerStatsManager.level;
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
        bool fire1Down = Input.GetButtonDown("Fire1");
        bool fire1Pressed = Input.GetButton("Fire1");
        bool fire1Up = Input.GetButtonUp("Fire1");

        bool fire2Down = Input.GetButtonDown("Fire2");
        bool fire2Pressed = Input.GetButton("Fire2");
        bool fire2Up = Input.GetButtonUp("Fire2");

        animator.SetBool("fire1", false);
        animator.SetBool("fire2", false);

        movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        gameObject.transform.Translate(movementDirection * Time.deltaTime * speed);

        // animation for the player.
        if(movementDirection != Vector3.zero)
        {
            if(movementDirection.x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if(health.curHealth <= 0)
        {
            GameOverUI.gameObject.SetActive(true);
            GameWinUI.gameObject.SetActive(false);
            LevelUpUI.gameObject.SetActive(false);
        }
        else if(playerStatsManager.level >= 5){
            Time.timeScale = 0f;
            GameWinUI.gameObject.SetActive(true);
            GameOverUI.gameObject.SetActive(false);
            LevelUpUI.gameObject.SetActive(false);
        }
        else if(playerStatsManager.level > LastFrameLevel){
            LastFrameLevel = playerStatsManager.level;
            Time.timeScale = 0f;
            LevelUpUI.gameObject.SetActive(true);
            GemCountLastFrame = GemCount;
        }
    }

    public void OnClickRestartButton()
    {
        // gameOverSection.SetActive(false);
        Time.timeScale = 1f;
        GemCount = 0;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        health.curHealth = health.maxHealth;

        playerStatsManager.level = 1;
        playerStatsManager.health = 100;

        transform.position = originalPosition;

        DestroyAllEnemies();

        GameOverUI.gameObject.SetActive(false);
    }

    public void DestroyAllEnemies(){
        // destroy all enemies and bullets
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        GameObject[] gems = GameObject.FindGameObjectsWithTag("Gem");
        foreach (GameObject gem in gems)
        {
            Destroy(gem);
        }
    }

    public void OnClickLevelUp(){
        Time.timeScale = 1f;
        LevelUpUI.gameObject.SetActive(false);
    }

    public void OnClickGameWin(){
        Time.timeScale = 1f;
        GemCount = 0;
        health.curHealth = health.maxHealth;
        transform.position = originalPosition;

        DestroyAllEnemies();

        playerStatsManager.level = 1;
        playerStatsManager.health = 100;

        GameWinUI.gameObject.SetActive(false);
    }
}

