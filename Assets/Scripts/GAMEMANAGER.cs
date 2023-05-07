using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class GAMEMANAGER : Singleton<GAMEMANAGER>
{
    [Header("Player")]
    public List<GameObject> playerPrefab;

    [Header("Enemy")]
    public List<GameObject> enemyPrefab;
}
