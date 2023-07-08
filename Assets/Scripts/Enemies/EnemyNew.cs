using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNew : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int attack = 50;
    public int health = 40;

    public int TotalStrength
    {
        get { return attack * health; }
    }

    public void CreateEnemy()
    {
        var a = Instantiate(enemyPrefab);
        a.transform.position = Vector3.zero;
    }
}
