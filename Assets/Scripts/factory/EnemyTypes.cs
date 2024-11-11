using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeA : IEnemy
{
    public void Spawn()
    {
        Debug.Log("Enemy Type A spawned");
    
    }
}

public class EnemyTypeB : IEnemy
{
    public void Spawn()
    {
        Debug.Log("Enemy Type B spawned");
     
    }
}
