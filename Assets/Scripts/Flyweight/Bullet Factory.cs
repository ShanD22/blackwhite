using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory
{
    private static Dictionary<string, GameObject> bullets = new Dictionary<string, GameObject>();

    public static GameObject GetBullet(bool isFacingRight)
    {
       
        string key = isFacingRight ? "RightBullet" : "LeftBullet";

        
        if (!bullets.ContainsKey(key))
        {
            bullets[key] = Resources.Load<GameObject>("Bullets/" + key);
        }

        return Object.Instantiate(bullets[key]);
    }
}
