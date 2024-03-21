using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIExperienceBar : MonoBehaviour
{
    public Slider experienceSlider;
    public PlayerStatsManager statsManager;
    public TMP_Text timerText;
    private float timer = 0f;

    void Start()
    {
        experienceSlider.maxValue = statsManager.maxExperience;
        experienceSlider.value = statsManager.currentExperience;
    }
    
    void Update()
    {
        // Update the timer by adding the time passed since the last frame
        timer += Time.deltaTime;

        // Format the timer value to display it in minutes and seconds
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");

        // Update the UI Text component to display the formatted timer value
        timerText.text = minutes + ":" + seconds;
    }

    public void SetExperience(float experience)
    {
        experienceSlider.value = experience;
    }

    public void UpdateExperienceUI(float currentExp, float maxExp)
    {
        experienceSlider.maxValue = maxExp;
        experienceSlider.value = currentExp;
    }
}

