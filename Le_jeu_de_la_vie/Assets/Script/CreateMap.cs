using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    public GameObject[,] _Grid;

    public GameObject clone;

    [SerializeField] public int _ColX = 10;
    [SerializeField] public int _ColY = 10;

    Vector3[] coo_object;
    private int[] indices;
    public Material MeshMaterial;

    public static CreateMap Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            //Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Init(); // Init Create map 
    }

    // Create Map 
    /////////////////////////////////////////////////////////////////////////////////////////////////////


    private void Init()
    {
        clone = MakeQuad();
        /*
        _Grid = new GameObject[_ColX, _ColY];
        
        for (int i = 0; i < _ColX; i++)
        {
            for (int j = 0; j < _ColY; j++)
            {
                Vector3 pos = new Vector3(i + 0.5f, j + 0.5f, 0.0f);
                string name = "quad" + (pos.x - 0.5).ToString() + " / " + (pos.y - 0.5).ToString();   // assigne un nom different pour chaque quad
                

                _Grid[i, j] = clone;
            }
        }
        */
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////




    // Fonction de creation de quad
    //###############################################################################################################
    public GameObject MakeQuad()
    {
        coo_object = new Vector3[(_ColX * _ColY) *4];
        indices = new int[(_ColX * _ColY) *6];


        int comptIndice = 0;
        int comptindex = 0;
        int compt = 0;


        for (int i = 0; i < _ColX; i++)
        {
            for (int j = 0; j < _ColY; j++)
            {
                coo_object[compt] = new Vector3(0.0f + i, 0.0f + j, 0.0f);
                compt++;
                coo_object[compt] = new Vector3(1.0f + i, 0.0f + j, 0.0f);
                compt++;
                coo_object[compt] = new Vector3(1.0f + i, 1.0f + j, 0.0f);
                compt++;
                coo_object[compt] = new Vector3(0.0f + i, 1.0f + j, 0.0f);
                compt++;

                indices[comptindex] = comptIndice;
                indices[comptindex + 1] = comptIndice +1;
                indices[comptindex + 2] = comptIndice +2;
                indices[comptindex + 3] = comptIndice;
                indices[comptindex + 4] = comptIndice +2;
                indices[comptindex + 5] = comptIndice + 3;
                comptIndice += 4;
                comptindex += 6;

            }
        }


        
        GameObject temp= BuildMesh(name, coo_object, indices);
        return temp;
    }

    protected GameObject BuildMesh(string gameObjectName, Vector3[] vertices, int[] indices, Vector2[] uvs = null)
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
        return primitive;
    }
    //###############################################################################################################

}
