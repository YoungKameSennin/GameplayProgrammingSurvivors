using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUISection
{
    private Transform trans;
    private Button restartButton;
    public Action OnClickRestartButtonAction;
    public GameOverUISection(Transform transform)
    {
        trans = transform;
        restartButton = trans.Find("RestartButton").GetComponent<Button>();
        restartButton.onClick.AddListener(OnClickRestartButton);
    }

    public void SetActive(bool state)
    {
        trans.gameObject.SetActive(state);
    }

    private void OnClickRestartButton()
    {
        OnClickRestartButtonAction?.Invoke();
    }
}