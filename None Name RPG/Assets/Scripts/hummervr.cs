using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class hummervr : MonoBehaviour {
    Vector3 mousePositionOnScreen;

    bool beginbuild=false;
    bool building=false;
    

    int bulidstage = 0;

    GameObject pre_building;
    GameObject Tower_building;

    public GameObject pre_stab;
    public GameObject pre_fire;
    public GameObject pre_bomb;
    public GameObject pre_cannon;

    public GameObject stab;
    public GameObject fire;
    public GameObject bomb;
    public GameObject cannon;


    GameObject pre_stab1;
    GameObject pre_fire1;
    GameObject pre_bomb1;
    GameObject pre_cannon1;

    public int build = 1;


    Quaternion roooo;
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
        roooo = pre_fire1.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit hitt = new RaycastHit();
        Ray ray = new Ray(this.transform.position, Vector3.down);
        Physics.Raycast(ray, out hitt,LayerMask.NameToLayer("map"));



        if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand) && bulidstage==0)
        {
            bulidstage = 1;
        }
        else if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(SteamVR_Input_Sources.RightHand) && bulidstage != 0)
        {
            bulidstage = 0;
        }
       
        if(SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            Vector3 aaaaa = roooo.eulerAngles;
            roooo = Quaternion.Euler(0+aaaaa.x,aaaaa.y+ 90, aaaaa.z+0) ;
        }
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
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.RightHand))
        {


            build = select();
        }
        Debug.Log(build);
       // Debug.Log(SteamVR_Input._default.inActions.touched);

        if(SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && bulidstage == 1)
        {
            bulidstage = 2;
        }
        else if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand) && bulidstage == 2)
        {
            bulidstage = 1;
        }

        if(bulidstage ==1)
        {
            if (hitt.collider != null && (hitt.collider.gameObject.tag == "wall" || hitt.collider.gameObject.tag == "road"))
            {
                switch (build)
                {
                    case 1:
                        {
                            pre_fire1.SetActive(false);
                           // pre_cannon1.SetActive(false);
                            pre_stab1.SetActive(false);
                            pre_bomb1.SetActive(false);
                            if (hitt.collider.gameObject.tag == "wall")
                            {
                                // Debug.Log("11");
                                pre_cannon1.SetActive(true);
                                pre_cannon1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y+1, (int)hitt.point.z);
                                pre_cannon1.transform.rotation = roooo;
                                Tower_building = cannon;
                                pre_building = pre_cannon1;
                            }
                            
                        }
                        break;
                    case 2:
                        {

                           // pre_fire1.SetActive(false);
                            pre_cannon1.SetActive(false);
                            pre_stab1.SetActive(false);
                            pre_bomb1.SetActive(false);
                            if (hitt.collider.gameObject.tag == "wall")
                            {
                               // Debug.Log("11");
                                pre_fire1.SetActive(true);
                                pre_fire1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y+1, (int)hitt.point.z);
                                pre_fire1.transform.rotation = roooo;
                                Tower_building = fire;
                                pre_building = pre_fire1;
                            }
                        }
                        break;
                    case 3:
                        {
                            pre_fire1.SetActive(false);
                            pre_cannon1.SetActive(false);
                            pre_stab1.SetActive(false);
                          //  pre_bomb1.SetActive(false);
                            if (hitt.collider.gameObject.tag == "road")
                            {
                                // Debug.Log("11");
                                pre_bomb1.SetActive(true);
                                pre_bomb1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y, (int)hitt.point.z);
                                pre_bomb1.transform.rotation = roooo;
                                Tower_building = bomb;
                                pre_building = pre_bomb1;
                            }
                        }
                            break;
                    case 4:
                        {
                            pre_fire1.SetActive(false);
                            pre_cannon1.SetActive(false);
                           // pre_stab1.SetActive(false);
                            pre_bomb1.SetActive(false);
                            if (hitt.collider.gameObject.tag == "road")
                            {
                                // Debug.Log("11");
                                pre_stab1.SetActive(true);
                                pre_stab1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y, (int)hitt.point.z);
                                pre_stab1.transform.rotation = roooo;
                                Tower_building = stab;
                                pre_building = pre_stab1;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        else if(bulidstage==0)
        {
            pre_fire1.SetActive(false);
            pre_cannon1.SetActive(false);
            pre_stab1.SetActive(false);
            pre_bomb1.SetActive(false);
        }
        //if (bulidstage == 2 )
        //{
        //    if(this.gameObject.GetComponent<Rigidbody>().velocity.y<-3)
        //    {

        //    }
        //}





        //    if(hitt.collider != null&& beginbuild)
        //    {
        //        //this.transform.position = hitt.point + new Vector3(0, 1, 0);

            //        if (hitt.collider.gameObject.tag == "wall" && (build == 1 || build == 2))
            //        {
            //            if (build == 1)
            //            {
            //                // Debug.Log("11");
            //                pre_cannon1.SetActive(true);
            //                pre_cannon1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y, (int)hitt.point.z);
            //            }
            //            else
            //            {
            //                pre_cannon1.SetActive(false);
            //            }
            //            if (build == 2)
            //            {
            //                // Debug.Log("11");
            //                pre_fire1.SetActive(true);
            //                pre_fire1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y, (int)hitt.point.z);
            //            }
            //            else
            //            {
            //                pre_fire1.SetActive(false);

            //            }
            //        }
            //        else
            //        {
            //            pre_fire1.SetActive(false);
            //            pre_cannon1.SetActive(false);
            //        }


            //        if (hitt.collider.gameObject.tag == "road" && (build == 3 || build == 4))
            //        {
            //            if (build == 3)
            //            {
            //                // Debug.Log("11");
            //                pre_bomb1.SetActive(true);
            //                pre_bomb1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y, (int)hitt.point.z);
            //            }
            //            else
            //            {
            //                pre_bomb1.SetActive(false);
            //            }
            //            if (build == 4)
            //            {
            //                // Debug.Log("11");
            //                pre_stab1.SetActive(true);
            //                pre_stab1.transform.position = new Vector3((int)hitt.point.x, (int)hitt.point.y, (int)hitt.point.z);
            //            }
            //            else
            //            {
            //                pre_stab1.SetActive(false);
            //            }
            //        }
            //        else
            //        {
            //            pre_stab1.SetActive(false);
            //            pre_bomb1.SetActive(false);
            //        }
            //    }
            //    else
            //    {

            //        pre_fire1.SetActive(false);
            //        pre_cannon1.SetActive(false);
            //        pre_stab1.SetActive(false);
            //        pre_bomb1.SetActive(false);
            //    }

    }



    int select()
    {

        //SteamVR_Input.platformer.inActions.Move.GetChanged(SteamVR_Input_Sources.Any);
        //SteamVR_Input._default.inActions.padpos.GetAxis(SteamVR_Input_Sources.RightHand)
        int a = 0;
        if (SteamVR_Input._default.inActions.padpos.GetAxis(SteamVR_Input_Sources.RightHand).x - SteamVR_Input._default.inActions.padpos.GetAxis(SteamVR_Input_Sources.RightHand).y > 0)
        {
            if (SteamVR_Input._default.inActions.padpos.GetAxis(SteamVR_Input_Sources.RightHand).x + SteamVR_Input._default.inActions.padpos.GetAxis(SteamVR_Input_Sources.RightHand).y > 0)
            {
                a = 2;
            }
            else
            {
                a = 1;
            }
        }
        else
        {
            if (SteamVR_Input._default.inActions.padpos.GetAxis(SteamVR_Input_Sources.RightHand).x + SteamVR_Input._default.inActions.padpos.GetAxis(SteamVR_Input_Sources.RightHand).y > 0)
            {
                a = 4;
            }
            else
            {
                a = 3;
            }
        }
        return a;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰得到");
        if (other.tag== "pre_tower")
        {
            Debug.Log("tag是塔");
            if (bulidstage == 2 )
            {
                Debug.Log("速度不对");
                Instantiate(Tower_building, pre_building.transform.position, roooo);
                bulidstage = 0;
            }
        }
    }
}
