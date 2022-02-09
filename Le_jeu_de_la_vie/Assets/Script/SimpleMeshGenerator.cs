using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMeshGenerator : MonoBehaviour
{
    [SerializeField] string choix;
    public Material MeshMaterial;

    Vector3[] coo_object;
    int[] indices;

    Vector2[] coo_material;

    void Start()
    {
        if (choix == "triangle")
        {
            MakeTriangle();
        }
        if (choix == "quad")
        {
            MakeQuad();
        }
        if(choix == "doublequad")
        {
            MakeDoubleQuad();
        }        
        
    }

    void MakeTriangle()
    {
        coo_object = new Vector3[] { 
            new Vector3(0.0f, 3.0f, 0.0f), 
            new Vector3(1.0f, 3.0f, 0.0f),
            new Vector3(1.0f, 4.0f, 0.0f),
        };


        indices = new int[] { 
            1, 2, 0
        };

        coo_material = new Vector2[] 
        { 
            new Vector2( 0.0f, 0.0f ),
            new Vector2( 0.5f, 1.0f ),
            new Vector2( 1.0f, 0.0f )
        };


        // TO DO: Vertices array of type Vector3
        // TO DO: Indices array of type int
        BuildMesh("triangle", coo_object, indices, coo_material);
        // TO DO: appeller la fonction BuildMesh avec les bons paramètres
    }

    void MakeQuad()
    {
        coo_object = new Vector3[] {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),

        };

        indices = new int[] {
            0, 1, 2, 0, 2, 3,
        };

        BuildMesh("triangle", coo_object, indices);
    }



    void MakeDoubleQuad()
    {
        coo_object = new Vector3[] {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 0.0f, 0.0f),
            new Vector3(1.0f, 1.0f, 0.0f),
            new Vector3(0.0f, 1.0f, 0.0f),

            new Vector3(2.0f, 0.0f, 0.0f),
            new Vector3(3.0f, 0.0f, 0.0f),
            new Vector3(3.0f, 1.0f, 0.0f),
            new Vector3(2.0f, 1.0f, 0.0f)

        };

        indices = new int[] {
            0, 1, 2, 0, 2, 3,
            4, 5, 6, 4, 6, 7
        };


        // TO DO: Vertices array of type Vector3
        // TO DO: Indices array of type int
        BuildMesh("triangle", coo_object, indices);
        // TO DO: appeller la fonction BuildMesh avec les bons paramètres

    }

    protected void BuildMesh(string gameObjectName, Vector3[] vertices, int[] indices, Vector2[] uvs = null)
    {
        // Search in the scene if there is a GameObject called "gameObjectName". If yes, we destroy it.
        GameObject oldOne = GameObject.Find(gameObjectName);
        if (oldOne != null)
            DestroyImmediate(oldOne);

        // Create a GameObject
        GameObject primitive = new GameObject(gameObjectName);
        
        // Add the components...
        MeshRenderer meshRenderer = primitive.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = primitive.AddComponent<MeshFilter>();
      
        // ... and set the mesh buffers. 
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.triangles = indices;
        meshFilter.mesh.uv = uvs;

        // Apply the material.
        if (MeshMaterial != null)
            meshRenderer.material = MeshMaterial;
    }
}
