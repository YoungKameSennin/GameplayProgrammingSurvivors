using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    private float modifiedSpeed;
    private Vector3 movementDirection; 
    public Transform GameOverUI;
    private GameOverUISection gameOverSection;
    private Vector3 originalPosition;

    void Awake()
    {
        transform.position = new Vector3(0, 0, 0);

        gameOverSection = new GameOverUISection(GameOverUI);
        // gameOverSection.SetActive(false);
        gameOverSection.OnClickRestartButtonAction = OnClickRestartButton;
        originalPosition = transform.position;
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

        movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        gameObject.transform.Translate(movementDirection * Time.deltaTime * speed);
    }

    private void OnClickRestartButton()
    {
        gameOverSection.SetActive(false);
        transform.position = originalPosition;
    }
}

