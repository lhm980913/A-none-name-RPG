using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Tower_Cannon : MonoBehaviour,Tower {

    public List<GameObject> enemyInRange;
    public GameObject bullet;

    private float CoolDown = 3;
    float time = 0;

    // Use this for initialization
    void Start () {
        enemyInRange = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyInRange.Count > 0)
        {
            while (time <= 0)
            {
                time = CoolDown;
                Attack(enemyInRange[0]);
            }

        }
        time -= Time.deltaTime;
        //Debug.Log("" + time);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
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

    public void Attack(GameObject go)
    {
        Debug.Log("Att");
        //go.GetComponent<Enemy_Enemy>().BeAttacked(5.0f);
        StartCoroutine(BulletFly(go));
    }

    IEnumerator BulletFly(GameObject go)
    {
        float t = 0;
        float flytime = 3;
        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
        while(t < flytime)
        {
            b.transform.position = Vector3.Lerp(transform.position, go.transform.position, t / flytime);
            t += Time.deltaTime;
            yield return null;
        }
        go.GetComponent<Enemy_Enemy>().BeAttacked(5.0f);
        
    }
    
}
