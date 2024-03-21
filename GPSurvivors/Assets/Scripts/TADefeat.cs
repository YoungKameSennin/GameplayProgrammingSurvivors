using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TADefeat : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Health>().curHealth <= 0)
        {
            Debug.Log("TA Defeated");
            FindObjectOfType<EnemySpawner>().TADefeated = true;
        }
    }
}
