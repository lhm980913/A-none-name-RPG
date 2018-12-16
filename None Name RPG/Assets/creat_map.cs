using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class creat_map : MonoBehaviour {
    //List<Transform> map;
    // Use this for initialization
    
     
    public  List<List<Transform>> map_ = new List<List<Transform>>();
    public Transform[] tr;

    float min_x, min_z, max_x, max_z;
    int w, h;
    Dictionary<int, float> map_posZ;
    void Start () {
        tr = this.gameObject.GetComponentsInChildren<Transform>();

        min_x = tr[0].position.x;
        min_z = tr[0].position.z;
        max_x = tr[0].position.x;
        max_z = tr[0].position.z;

         List<float> posZ = new List<float>();

      
        //for(int i=0;i<tr.Length;i++)
        //{
        //    posZ.Add(tr[i].position.z);
        //}
        for (int i=0;i<tr.Length;i++)
        {
            
            //确定图片大小
            if (tr[i].position.x-(tr[i].localScale.x/2) < min_x)
                min_x = tr[i].position.x- (tr[i].localScale.x / 2);
            if (tr[i].position.x + (tr[i].localScale.x / 2) > max_x)
                max_x = tr[i].position.x+ (tr[i].localScale.x / 2);
            if (tr[i].position.z - (tr[i].localScale.z / 2) < min_z)
                min_z = tr[i].position.z- (tr[i].localScale.z / 2);
            if (tr[i].position.z + (tr[i].localScale.z / 2) > max_z)
                max_z = tr[i].position.z+(tr[i].localScale.z / 2);

            if(!isrepeat(posZ,tr[i].position.y))
            {
                posZ.Add(tr[i].position.y);
                List<Transform> aa=new List<Transform>();
                aa.Add(tr[i]);
                map_.Add(aa);
            }
            else
            {
                for(int z=0;z<map_.Count;z++)
                {
                    if(tr[i].position.y == map_[z][0].position.y)
                    {
                        map_[z].Add(tr[i]);
                    }
                }
            }

        }
        //图片尺寸
        w = 256;
        h = 256;
        
        //遍历图片层数
        for(int i=0;i<map_.Count;i++)
        {
            
            Texture2D mmmmmmm = new Texture2D(w,h);
            string filespath = "Assets/"+i+".png";
            //全部刷黑
            for (int z=0;z<w;z++)
            {
                for(int x=0;x<h;x++)
                {
                    mmmmmmm.SetPixel(z, x, Color.black);
                }
            }
            //遍历每层方块刷白
            for(int j=0; j<map_[i].Count;j++)
            {
               for(int z=0;z<map_[i][j].localScale.x; z++)
                {
                    for (int x = 0; x < map_[i][j].localScale.z; x++)
                    {
                        mmmmmmm.SetPixel((int)(map_[i][j].position.x - map_[i][j].localScale.x / 2 + z - min_x),(int) (map_[i][j].position.z - map_[i][j].localScale.z / 2 + x - min_z), Color.white);

                    }
                }               
            }
            var bys = mmmmmmm.EncodeToPNG();
            File.WriteAllBytes(filespath, bys);
        }


	}
	
    bool isrepeat(List<float> posZ,float z)
    {
        if (posZ.Count == 0)
            return false;
        for(int i=0;i<posZ.Count;i++)
        {
            if(posZ[i]==z)
            {
                return true;
            }
        }
        return false;
    }


	// Update is called once per frame
	void Update () {
		
	}
}
