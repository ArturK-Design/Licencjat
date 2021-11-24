using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public Text enemyCount;
    GameObject[] enemies;
    void Start()
    {
        
    }

    private void Update()
    {
        enemyCount = GameObject.Find("PlayerUI/EnemyCount").GetComponent<Text>();
        enemies = GameObject.FindGameObjectsWithTag("Count");
        enemyCount.text = enemies.Length.ToString();
    }
}


