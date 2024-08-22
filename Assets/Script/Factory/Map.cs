using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Map : MonoBehaviour
{
    [HideInInspector]   
    public List<List<Transform>> transformAssemble;
    private int x = 13;
    private int y = 9;
    private GameObject mapLineAssemble;
    private void Start()
    {
        transformAssemble= new List<List<Transform>>();
        for(int i = 0; i < x; i++)
        {
            List<Transform> row = new List<Transform>();
            for (int j = 0;j<y; j++)
            {
                row.Add(null);
            }
            transformAssemble.Add(row);
        }
        mapLineAssemble = new GameObject("MapLines");
        for (int j = 0; j < y + 1; j++)
        {
            GameObject line = Instantiate(Resources.Load("Prefab/mapLine") as GameObject);
            line.transform.parent = mapLineAssemble.transform;
            LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
            Vector3[] positions = new Vector3[2];
            positions[0] = new Vector3(- 7.5f, j - 4.5f, 0);
            positions[1] = new Vector3( 5.5f, j - 4.5f, 0);
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(positions);
        }
        for (int i = 0; i < x + 1; i++)
        {
            GameObject line = Instantiate(Resources.Load("Prefab/mapLine") as GameObject);
            line.transform.parent = mapLineAssemble.transform;
            LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
            Vector3[] positions = new Vector3[2];
            positions[0] = new Vector3(i - 7.5f,  -4.5f, 0);
            positions[1] = new Vector3(i - 7.5f,  4.5f, 0);
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(positions);
        }
        mapLineAssemble.SetActive(false);
    }
    public void ShowAndShutLine(bool flag)
    {
        mapLineAssemble.SetActive(flag);
    }
    public bool AddThing(Vector3 BlurPosition,GameObject thing)
    {
        if (BlurPosition.x < -7.5f || BlurPosition.y < -4.5f || BlurPosition.x > 5.5f || BlurPosition.y > 4.5f)
            return false;
        int i = (int)(BlurPosition.x +7.5f)-7;
        int j = (int)(BlurPosition.y + 4.5f) - 4;
        transformAssemble[i + 7][j + 4] = thing.transform;
        thing.transform.position = new Vector3(i, j, 0);
        return true;
    }
    public bool RemoveThing(Vector3 BlurPosition)
    {
        if (BlurPosition.x < -7.5f || BlurPosition.y < -4.5f || BlurPosition.x > 5.5f || BlurPosition.y > 4.5f)
            return false;
        int i = (int)(BlurPosition.x + 7.5f) - 7;
        int j = (int)(BlurPosition.y + 4.5f) - 4;
        Transform thing =transformAssemble[i + 7][j + 4];
        if (thing == null)
            return false;
        Destroy(thing.gameObject);
        transformAssemble[i + 7][j + 4] = null;
        return true;
    }
}

