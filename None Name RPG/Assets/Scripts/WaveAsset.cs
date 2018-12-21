using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public enum EnemyClass
{
    Big,
    Medium,
    Small
}

[System.Serializable]
public struct enemyWave
{
    public EnemyClass enemyClass;
    public int number;
    public float deltaTime;
}

[System.Serializable]
public struct Waves
{
   public List<enemyWave> Order;
}

[CreateAssetMenu(fileName = "Assets/Wave.asset")]
public class WaveAsset : ScriptableObject {
    public List<Waves> waves;
}
