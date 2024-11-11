using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyFactory
{
    public static IEnemy CreateEnemy(string enemyType)
    {
        switch (enemyType)
        {
            case "A":
                return new EnemyTypeA();
            case "B":
                return new EnemyTypeB();
            default:
                throw new System.ArgumentException("Tipo de enemigo desconocido");
        }
    }
}
