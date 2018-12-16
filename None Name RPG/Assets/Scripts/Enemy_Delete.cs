using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Delete : MonoBehaviour {

    public delegate void EnemyDelete(GameObject go);
    public EnemyDelete enemydelete;

	// Use this for initialization
	void Start () {
		
	}

    private void OnDestroy()
    {
        if (enemydelete != null)
            enemydelete(gameObject);
    }
}
