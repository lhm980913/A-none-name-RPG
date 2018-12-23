using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Bomb : MonoBehaviour,Tower {
    public List<GameObject> enemyInRange;
    public float force;
    // Use this for initialization
    void Start () {
        enemyInRange = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        if (enemyInRange.Count > 0)
        {
           
            for (int i=0;i<enemyInRange.Count;i++)
            {
                Attack(enemyInRange[i]);
            }

        }
       
    }
    public void Attack(GameObject enemy)
    {
      
      //  enemy.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Acceleration);
        //go.GetComponent<Enemy_Enemy>().BeAttacked(5.0f);
        StartCoroutine(Lunch(force,enemy));
        enemy.GetComponent<Enemy_FindWayAndMove>().enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyInRange.Add(other.gameObject);
            Enemy_Delete del = other.gameObject.GetComponent<Enemy_Delete>();
            del.enemydelete += OnEnemyDestroy;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyInRange.Remove(other.gameObject);
            Enemy_Delete del = other.gameObject.GetComponent<Enemy_Delete>();
            del.enemydelete -= OnEnemyDestroy;
        }
    }

    private void OnEnemyDestroy(GameObject go)
    {
        enemyInRange.Remove(go);
    }


    IEnumerator Lunch(float force, GameObject enemy)
    {

        enemy.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Acceleration);


        yield return new WaitForSeconds(2);
        if(enemy!=null)
        {
            enemy.GetComponent<Enemy_Enemy>().BeAttacked(99);
        }
       
        yield return null;

    }
}
