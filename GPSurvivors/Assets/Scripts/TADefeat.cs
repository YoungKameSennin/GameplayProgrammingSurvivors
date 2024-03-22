using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TADefeat : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<Health>().curHealth <= 0)
        {
            FindObjectOfType<EnemySpawner>().TADefeated = true;
        }
    }
}
