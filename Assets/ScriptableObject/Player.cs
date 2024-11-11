using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPlayer", menuName = "Entities/Player Data", order = 1)]
public class Player : ScriptableObject
{
    public Color Color;
    public float MoveSpeed;
    public Sprite playerSprite;


}

