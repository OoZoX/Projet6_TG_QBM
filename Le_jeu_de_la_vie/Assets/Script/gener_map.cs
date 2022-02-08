using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gener_map : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    private GameObject[,] _Grid;


    [SerializeField] private int _ColX = 10;
    [SerializeField] private int _ColY = 10;




    private void Awake()
    {
        _Grid = new GameObject[_ColX, _ColY];
        for (int i = 0; i < _ColX; i++)
        {
            for (int j = 0; j < _ColY; j++)
            {
                Vector3 pos = new Vector3(i, j, 0);
                GameObject clone = Instantiate(prefab, pos, Quaternion.identity);
                _Grid[i, j] = clone;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


}