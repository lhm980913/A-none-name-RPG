using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Fire : MonoBehaviour,Tower{
    public GameObject Fire_Particle;
    public List<GameObject> enemyInRange;
    GameObject burn;

    public bool attacking = false;


  
    // Use this for initialization
    void Start () {
        Switch_Fire.Fire_Tower.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
       attacking = Switch_Fire.fire;


        if (attacking && Switch_Fire.energy >= 0)
        {

            
            if(burn==null)
            {
                burn = Instantiate(Fire_Particle, this.transform.position, this.transform.rotation);
            }
          
            for (int i = 0; i < enemyInRange.Count ; i++)
            {
                

                Attack(enemyInRange[i]);
            }

        }
        else { Destroy(burn); }
        if (Switch_Fire.energy < 100&&!attacking)
        {
            Destroy(burn);
           
        }
     

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
    public  void Attack(GameObject enemy)
    {
        Debug.Log("Att");
        //go.GetComponent<Enemy_Enemy>().BeAttacked(5.0f);
       
       
            enemy.GetComponent<Enemy_Enemy>().BeAttacked(5.0f*Time.deltaTime);
        
    }


}
