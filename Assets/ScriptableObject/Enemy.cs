using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[CreateAssetMenu(fileName = "NewEnemy", menuName = "Entities/Enemy Data", order = 0)]
public class Enemy : ScriptableObject
{
    public Color Color;
    public float MoveSpeed;
    public Sprite enemySprite;

            
}
