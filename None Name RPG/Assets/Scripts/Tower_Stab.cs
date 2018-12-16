using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Stab : MonoBehaviour ,Tower{
    public GameObject Stab;

    public List<GameObject> enemyInRange;


    bool attacking = false;



    Vector3 pos1;
    Vector3 pos2 ;
    // Use this for initialization
    void Start () {
		Switch_Stab.Stab_Tower.Add(this.gameObject);

        

    }
	
	// Update is called once per frame
	void Update () {
        attacking = Switch_Stab.att;


        if (attacking)
        {
            StartCoroutine(stab_up(Stab));
            Debug.Log("11");
            for (int i = 0; i < enemyInRange.Count; i++)
            {
               
                Attack(enemyInRange[i]);
            }

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
    public void Attack(GameObject enemy)
    {
        Debug.Log("Att");
        //go.GetComponent<Enemy_Enemy>().BeAttacked(5.0f);

       
        enemy.GetComponent<Enemy_Enemy>().BeAttacked(20.0f);
        
    }
    IEnumerator stab_up(GameObject Stab)
    {
        GameObject sss = Instantiate(Stab, this.transform.position - Vector3.up, this.transform.rotation);
        pos1 = sss.transform.position ;
        pos2 = sss.transform.position + Vector3.up*2;
        float t = 0;
        while (t < 1)
        {

            if (sss != null)
            {
                sss.transform.position = Vector3.Lerp(pos1, pos2, t / 1);
            }
          
                
            t += Time.deltaTime*8;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        if(sss!=null)
        {
            Destroy(sss);
        }
    }
}
