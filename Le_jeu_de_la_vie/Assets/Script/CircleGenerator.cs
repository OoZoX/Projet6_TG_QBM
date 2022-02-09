using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleGenerator : SimpleMeshGenerator
{
    [Range(5, 30)]
    public int CircleSides = 10;
    [Range(1f, 3f)]
    [SerializeField] float CircleRadius = 2f;

    List<Vector3> verticides;
    List<Vector3> index;
    


    public bool RecomputeCircle = false;

    void Start()
    {
        MakeCircle();
    }

    private void Update()
    {
        if (RecomputeCircle)
        {
            RecomputeCircle = false;
            MakeCircle();
        }
    }

    void MakeCircle()
    {
        // TO DO
        verticides = new List<Vector3>();

        for (int i = 0; i < CircleSides; i++)
        {
            verticides.Add(new Vector3(
                0.0f, 
                Mathf.Cos(Mathf.PI / 2) * CircleRadius, 
                Mathf.Sin(Mathf.PI / 2) * CircleRadius
                ));
            verticides.Add(new Vector3(
                0.0f,
                Mathf.Cos(Mathf.PI/2) * CircleRadius,
                Mathf.Sin(Mathf.PI / 2) * CircleRadius
                ));  
                
            index.Add(new Vector3(0, i, i+1));

        }





        //BuildMesh("cercle", verticides, index);
    }
}
