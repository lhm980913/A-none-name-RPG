using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class hummervr : MonoBehaviour {
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


        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    build = 1;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    build = 2;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    build = 3;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    build = 4;
        //}
        //build = select();
        Debug.Log(build);
     //   Debug.Log(SteamVR_Input._default.inActions.touchpos.GetAxis(SteamVR_Input_Sources.RightHand));




        RaycastHit hitt = new RaycastHit();
        Ray ray = new Ray(this.transform.position, Vector3.down);
        Physics.Raycast(ray, out hitt);
        
        if(hitt.collider != null)
        {
            //this.transform.position = hitt.point + new Vector3(0, 1, 0);

            if (hitt.collider.gameObject.tag == "wall" && (build == 1 || build == 2))
            {
                if (build == 1)
                {
                    // Debug.Log("11");
                    pre_cannon1.SetActive(true);
                    pre_cannon1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y, (int)hitt.point.z);
                }
                else
                {
                    pre_cannon1.SetActive(false);
                }
                if (build == 2)
                {
                    // Debug.Log("11");
                    pre_fire1.SetActive(true);
                    pre_fire1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y, (int)hitt.point.z);
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


            if (hitt.collider.gameObject.tag == "road" && (build == 3 || build == 4))
            {
                if (build == 3)
                {
                    // Debug.Log("11");
                    pre_bomb1.SetActive(true);
                    pre_bomb1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y, (int)hitt.point.z);
                }
                else
                {
                    pre_bomb1.SetActive(false);
                }
                if (build == 4)
                {
                    // Debug.Log("11");
                    pre_stab1.SetActive(true);
                    pre_stab1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y, (int)hitt.point.z);
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



    //int select()
    //{

    //    //SteamVR_Input.platformer.inActions.Move.GetChanged(SteamVR_Input_Sources.Any);
        
    //    int a = 0;
    //    if(SteamVR_Input._default.inActions.touchpos.GetAxis(SteamVR_Input_Sources.RightHand).x- SteamVR_Input._default.inActions.touchpos.GetAxis(SteamVR_Input_Sources.RightHand).y >0)
    //    {
    //        if(SteamVR_Input._default.inActions.touchpos.GetAxis(SteamVR_Input_Sources.RightHand).x + SteamVR_Input._default.inActions.touchpos.GetAxis(SteamVR_Input_Sources.RightHand).y > 0)
    //        {
    //            a = 2;
    //        }
    //        else
    //        {
    //            a = 1;
    //        }
    //    }
    //    else
    //    {
    //        if(SteamVR_Input._default.inActions.touchpos.GetAxis(SteamVR_Input_Sources.RightHand).x + SteamVR_Input._default.inActions.touchpos.GetAxis(SteamVR_Input_Sources.RightHand).y > 0)
    //        {
    //            a = 4;
    //        }
    //        else
    //        {
    //            a = 3;
    //        }
    //    }
    //    return a;
    //}
    
}
