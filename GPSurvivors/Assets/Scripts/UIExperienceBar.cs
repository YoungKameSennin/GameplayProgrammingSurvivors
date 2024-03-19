using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExperienceBar : MonoBehaviour
{
    public Slider experienceSlider;
    public PlayerStatsManager statsManager;

    void Start()
    {
        experienceSlider.maxValue = statsManager.maxExperience;
        experienceSlider.value = statsManager.currentExperience;
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

