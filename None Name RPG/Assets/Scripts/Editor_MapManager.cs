using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Grid_Type
{
    obstacle,
    pass
}

public class Grid
{
    public Grid_Type type;
    public Vector2Int Pos;
    public Vector3Int FGH;
    public Vector2Int parent;

    public Grid()
    {
        type = Grid_Type.pass;
        Pos = Vector2Int.zero;
        FGH = Vector3Int.zero;
        parent = Vector2Int.zero;
    }
}

public class Map
{
    public int row
    {
        get{ return Row;}
    }
    public int colum
    {
        get { return Colum; }
    }
    //private properties
    private int Row;
    private int Colum;
    private Grid[,] grids;
    private Vector2Int Start;
    private Vector2Int End;
    private List<Grid> Path;
    //public Methods
    public Map(Texture2D texture, Vector2Int start,Vector2Int end) {
        //Initialize Map's Row and Colum
        Row = texture.width;
        Colum = texture.height;
        grids = new Grid[Row, Colum];

        //Initialize Start and End
        Start = start;
        End = end;

        //Initizalize Grids Info
        InitGrids(texture);

        //Initizalize Path
        Path = new List<Grid>();
        InitPath();
    }
    //private Methods
    private void InitGrids(Texture2D tex) {

        for(int i = 0; i < Row; i++)
        {
            for(int j = 0; j < Colum; j++)
            {
                grids[i, j] = new Grid();

                if (tex.GetPixel(i, j) == Color.black)
                {
                    grids[i, j].type = Grid_Type.obstacle;
                    //Debug.Log("Obstacle" + i + j);
                }
                else
                {
                    grids[i, j].type = Grid_Type.pass;
                    Debug.Log("Pass" + i + j);
                }
                    

                grids[i, j].Pos = new Vector2Int(i, j);
                int H = GetManhattanDistance(grids[i, j].Pos);
                grids[i, j].FGH = new Vector3Int(0,0,H);

                
            }
        }
        
    }
    private void InitPath() {
        List<Grid> openList = new List<Grid>();
        List<Grid> closeList = new List<Grid>();

        openList.Add(GetGrid(Start));

        Grid cur = new Grid();

        Grid endGrid = GetGrid(End);

        while (!(closeList.Contains(endGrid) || openList.Count == 0))
        {
            traversalAndFindCurrenGrid(ref cur, openList);

            if (!openList.Remove(cur))
                Debug.Log("Error:delete" + cur.Pos);
            closeList.Add(cur);

            SearchGridAround(cur, ref openList, closeList);
            if (openList.Count + closeList.Count >= Row * Colum)
            {   
                break;
            }
        }

        Path.Add(GetGrid(End));
        cur = GetGrid(endGrid.parent);

        int count = 0;
        while (!cur.Equals(GetGrid(Start)))
        {
            Path.Add(cur);
            cur = GetGrid(cur.parent);
            count++;
            if (count >= Row * Colum)
            {
                break;
            }
        }

        
    }

    private void traversalAndFindCurrenGrid(ref Grid cur, List<Grid> openlist)
    {
        Grid tempGrid = openlist[0];
        for (int i = 0; i < openlist.Count; i++)
        {
            if (openlist[i].FGH.x < tempGrid.FGH.x)
            {
                tempGrid = openlist[i];
                break;
            }
        }
        cur = tempGrid;
    }

    private void SearchGridAround(Grid cur,ref List<Grid> openlist, List<Grid> closelist) {
        List<Grid> neighbors = new List<Grid>();
        if(cur.Pos.x != 0)
        {
            neighbors.Add(GetGrid(cur.Pos + new Vector2Int(-1, 0)));
        }
        if(cur.Pos.x != (Row - 1))
        {
            neighbors.Add(GetGrid(cur.Pos + new Vector2Int(1, 0)));
        }
        if (cur.Pos.y != 0)
        {
            neighbors.Add(GetGrid(cur.Pos + new Vector2Int(0, -1)));
        }
        if (cur.Pos.y != (Colum - 1))
        {
            neighbors.Add(GetGrid(cur.Pos + new Vector2Int(0, 1)));
        }
        //Debug.Log("Right" + cur.Pos + neighbors.Count);
        for (int i = 0; i < neighbors.Count; i++)
        {
            Grid grid = neighbors[i];
            //Debug.Log(cur.Pos + "  " + grid.Pos + i);
            if(grid.type != Grid_Type.obstacle)
            {
                if (closelist.Contains(grid))
                {
                    //Debug.Log("close" + grid.Pos);
                    continue;
                }
                else
                {
                    if (openlist.Contains(grid))
                    {
                        if (grid.FGH.y > (cur.FGH.y + 1))
                        {
                            grid.parent = cur.Pos;
                            grid.FGH.y = cur.FGH.y + 1;
                            grid.FGH.x = grid.FGH.y + grid.FGH.z;
                            
                            //Debug.Log("InOpen" + grid.Pos);
                        }
                    }
                    else
                    {
                        grid.parent = cur.Pos;
                        grid.FGH.y = cur.FGH.y + 1;
                        grid.FGH.x = grid.FGH.y + grid.FGH.z;
                        openlist.Add(grid);
                       
                        //Debug.Log("NoOpenNoClose" + grid.Pos);
                    }
                }
            }
            else
            {
                //Debug.Log("ob" + grid.Pos);
            }
            
        }
        
    }

    private int GetManhattanDistance(Vector2Int pos) {
        return Mathf.Abs(Start.x - pos.x) + Mathf.Abs(Start.y - pos.y);
    }
    //public Methdos
    public Grid GetGrid (Vector2Int pos)
    {
        return grids[pos.x, pos.y];
    }
    //static Methods
    static public void CreatePath(Texture2D tex, Vector2Int start, Vector2Int end)
    {
        string path = "Assets/Path/Way.asset";
        Way way = ScriptableObject.CreateInstance<Way>();
        Map map = new Map(tex, start,end);
        //way.Path.Add(end);
        for(int i = 0; i < map.Path.Count; i++)
        {
            way.Path.Add(map.Path[i].Pos);
        }
        way.Path.Add(start);
        UnityEditor.AssetDatabase.CreateAsset(way, path);
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();

    }
}


