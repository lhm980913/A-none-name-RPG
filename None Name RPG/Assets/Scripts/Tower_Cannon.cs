﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Tower_Cannon : MonoBehaviour,Tower {

    public List<GameObject> enemyInRange;
    public GameObject bullet;

    private float CoolDown = 1;
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
            time -= Time.deltaTime;
            Vector3 dir = -this.transform.position + enemyInRange[0].transform.position;
            Vector3 ddddd = new Vector3();
            this.transform.forward = Vector3.SmoothDamp(this.transform.forward, new Vector3(dir.x, 0, dir.z), ref ddddd, Time.deltaTime * 5);
        }
        
        //Debug.Log("" + time);

        

        
        //this.transform.forward = new Vector3(dir.x, 0, dir.z);
        
       // this.transform.rotation = Quaternion.Euler(0, ro_y*180/Mathf.PI, 0);
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
        //Debug.Log("Att");
        //go.GetComponent<Enemy_Enemy>().BeAttacked(5.0f);
        StartCoroutine(BulletFly(go));
    }

    IEnumerator BulletFly(GameObject go)
    {
        float t = 0;
        float flytime = 0.6f;
        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
        while(t < flytime)
        {
            if (go != null)
            {
                b.transform.position = Vector3.Lerp(transform.position, go.transform.position, t / flytime);
                t += Time.deltaTime;
            }
            else
            {
                Destroy(b);
            }
            
            yield return null;
        }
        if(go != null)
        {
            go.GetComponent<Enemy_Enemy>().BeAttacked(5.0f);
        }

        if(b!=null)
        {
            Destroy(b);
        }
        
    }
    
}
