using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIButtonSetter : MonoBehaviour
{
    public TMP_Text textMesh1;
    public TMP_Text textMesh2;
    public TMP_Text textMesh3;


    void Start()
    {
    }

    public int setTexts(List<UpgradeOption> options)
    {
        
        switch (options[0])
        {
            case UpgradeOption.IncreaseBullets:
                textMesh1.text = "Fire Ball + 1";
                break;
            case UpgradeOption.IncreaseShieldHealth:
                textMesh1.text = "Get Shield Enhance";
                break;
            case UpgradeOption.IncreaseIceBall:
                textMesh1.text = "Ice Ball + 1";
                break;
            case UpgradeOption.IncreaseMarryGoRound:
                textMesh1.text = "Marry Go Round + 2";
                break;
            case UpgradeOption.IncreaseAPbullet:
                textMesh1.text = "AP Bullet + 1";
                break;
        }

        switch (options[1])
        {
            case UpgradeOption.IncreaseBullets:
                textMesh2.text = "Fire Ball + 1";
                break;
            case UpgradeOption.IncreaseShieldHealth:
                textMesh2.text = "Get Shield Enhance";
                break;
            case UpgradeOption.IncreaseIceBall:
                textMesh2.text = "Ice Ball + 1";
                break;
            case UpgradeOption.IncreaseMarryGoRound:
                textMesh2.text = "Marry Go Round + 2";
                break;
            case UpgradeOption.IncreaseAPbullet:
                textMesh2.text = "AP Bullet + 1";
                break;
        }

        switch (options[2])
        {
            case UpgradeOption.IncreaseBullets:
                textMesh3.text = "Fire Ball + 1";
                break;
            case UpgradeOption.IncreaseShieldHealth:
                textMesh3.text = "Get Shield Enhance";
                break;
            case UpgradeOption.IncreaseIceBall:
                textMesh3.text = "Ice Ball + 1";
                break;
            case UpgradeOption.IncreaseMarryGoRound:
                textMesh3.text = "Marry Go Round + 2";
                break;
            case UpgradeOption.IncreaseAPbullet:
                textMesh3.text = "AP Bullet + 1";
                break;
        }
        

        return 0;

    }
}
