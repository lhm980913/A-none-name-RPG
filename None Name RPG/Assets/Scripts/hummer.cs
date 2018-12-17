using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hummer : MonoBehaviour {
    Vector3 mousePositionOnScreen;

    public GameObject pre_stab;
    public GameObject pre_fire;
    public GameObject pre_bomb;
    public GameObject pre_cannon;

    GameObject pre_stab1;
    GameObject pre_fire1;
    GameObject pre_bomb1;
    GameObject pre_cannon1;

    public int build = 1;

    // Use this for initialization
    void Start () {
        pre_stab1 = Instantiate(pre_stab);
        pre_stab1.SetActive(false);
        pre_fire1 = Instantiate(pre_fire);
        pre_fire1.SetActive(false);
        pre_bomb1 = Instantiate(pre_bomb);
        pre_bomb1.SetActive(false);
        pre_cannon1 = Instantiate(pre_cannon);
        pre_cannon1.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        mousePositionOnScreen = Input.mousePosition;
       
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            build = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            build = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            build = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            build = 4;
        }


        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);


        RaycastHit hitt = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitt);
        
        this.transform.position = hitt.point+new Vector3(0,1,0);

        if(hitt.collider.gameObject.tag=="wall"&&(build==1||build==2))
        {
            if(build==1)
            {
               // Debug.Log("11");
                pre_cannon1.SetActive(true);
                pre_cannon1.transform.position = new Vector3((int)this.transform.position.x, (int)this.transform.position.y, (int)this.transform.position.z);
            }
            else
            {
                pre_cannon1.SetActive(false);
            }
            if (build == 2)
            {
                // Debug.Log("11");
                pre_fire1.SetActive(true);
                pre_fire1.transform.position = new Vector3((int)this.transform.position.x, (int)this.transform.position.y, (int)this.transform.position.z);
            }
            else
            {
                pre_fire1.SetActive(false);

            }
        }
        else
        {
            pre_fire1.SetActive(false);
            pre_cannon1.SetActive(false);
        }
    

        if (hitt.collider.gameObject.tag == "road"&&(build == 3 || build == 4))
        {
            if (build == 3)
            {
                // Debug.Log("11");
                pre_bomb1.SetActive(true);
                pre_bomb1.transform.position = new Vector3((int)this.transform.position.x, (int)this.transform.position.y, (int)this.transform.position.z);
            }
            else
            {
                pre_bomb1.SetActive(false);
            }
            if (build == 4)
            {
                // Debug.Log("11");
                pre_stab1.SetActive(true);
                pre_stab1.transform.position = new Vector3((int)this.transform.position.x, (int)this.transform.position.y, (int)this.transform.position.z);
            }
            else
            {
                pre_stab1.SetActive(false);
            }
        }
        else
        {
            pre_stab1.SetActive(false);
            pre_bomb1.SetActive(false);
        }



    }
}
