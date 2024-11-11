using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public void SpawnEnemy(string enemyType)
    {
        IEnemy enemy = EnemyFactory.CreateEnemy(enemyType);
        enemy.Spawn();
    }

    void Start()
    {
      
        SpawnEnemy("A");
        SpawnEnemy("B");
    }
}
