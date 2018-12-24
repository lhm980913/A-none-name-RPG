using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Manager_WaveManager : MonoBehaviour {

    public EnemyAsset Big;
    public EnemyAsset Medium;
    public EnemyAsset Small;

    public GameObject enemyPrefab;
    public GameObject BigEnemy;

    public WaveAsset waveAsset;
    public PathAsset pathAsset;


    public void WaveStart(int i)
    {
        //Debug.Log(gameObject.name+" Start Wave " + i);
        StartCoroutine("InWave", i);
    }

    public void WaveStop()
    {
        Debug.Log(gameObject.name + " End Wave");
    }

    IEnumerator InWave(int index)
    {
        for(int i = 0;i< waveAsset.waves.Count; i++)
        {
            for(int orderCount = 0;orderCount< waveAsset.waves[index].Order.Count; orderCount++)
            {
                yield return StartCoroutine(CreatEnemyFromAsset(waveAsset.waves[index].Order[orderCount]));
            }
        }
    }

    IEnumerator CreatEnemyFromAsset(enemyWave enemywave)
    {
        float time = enemywave.deltaTime;
        for(int number = 0; number < enemywave.number; number++)
        {
            //Debug.Log("A " + enemywave.enemyClass.ToString() + " enemy " + number);
            CreateEnemy(enemywave.enemyClass);
            yield return new WaitForSeconds(time);
        }
    }

    void CreateEnemy(EnemyClass enemyClass)
    {
        GameObject go;
        //GameObject go = Instantiate(enemyPrefab, pathAsset.way[0],Quaternion.identity);

        switch (enemyClass)
        {
            case EnemyClass.Big:
                go = Instantiate(BigEnemy);
                break;
            case EnemyClass.Medium:
                go = Instantiate(enemyPrefab);
                break;
            default:
                go = Instantiate(enemyPrefab);
                break;
        }
        if (enemyClass == EnemyClass.Medium)
        {
            
        }
        else
        {
            
        }
        
        go.GetComponent<Enemy_FindWayAndMove>().SetPath(pathAsset);
    }

}
