using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMap : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    public GameObject[,] _Grid;
    private GameObject[,] _GridTemp;

    public Slider sliderUI;

    [SerializeField] public int _ColX = 10;
    [SerializeField] public int _ColY = 10;

    public static CreateMap Instance;


    private void Awake()
    {
        CreateFirstMap(); 
    }


    private void CreateFirstMap()
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
        _Grid = new GameObject[_ColX, _ColY];
        for (int i = 0; i < _ColX; i++)
        {
            for (int j = 0; j < _ColY; j++)
            {
                Vector3 pos = new Vector3(i + 0.5f, j + 0.5f, 0);
                GameObject clone = Instantiate(prefab, pos, Quaternion.identity);
                _Grid[i, j] = clone;

            }
        }
    }
    public void ChangeSizeMap(int x, int y)
    {
        _GridTemp = new GameObject[x, y];

        if (x < _ColX)
        {
            ReductMap(x, y);
        }
        else if (x > _ColX)
        {
            ExpendMap(x, y);
        }
        else
        {
            Debug.Log("same size");
        }
    }

    private void ReductMap(int x, int y)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                _GridTemp[i, j] = _Grid[i, j];
            }
        }
        _Grid = new GameObject[x, y];
        _Grid = _GridTemp;
    }

    private void ExpendMap(int x, int y)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (i >= _ColX || j >= _ColY)
                {
                    Vector3 pos = new Vector3(i + 0.5f, j + 0.5f, 0);
                    GameObject clone = Instantiate(prefab, pos, Quaternion.identity);
                    _GridTemp[i, j] = clone;
                }
                else
                {
                    _GridTemp[i, j] = _Grid[i, j];
                }
            }
        }
        _Grid = new GameObject[x, y];
        _Grid = _GridTemp;
    }
    
}
