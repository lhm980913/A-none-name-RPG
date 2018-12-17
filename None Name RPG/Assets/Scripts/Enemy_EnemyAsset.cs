using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy.asset")]
public class EnemyAsset : ScriptableObject {
    
    public float MaxSpeed;
    public float MaxHealth;
    public int Money;
    public int Money_range;
}
