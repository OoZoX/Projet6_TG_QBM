using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class CreateMap : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    public GameObject[,] _Grid;

    public Slider sliderUI;

    [SerializeField] public int _Cols = 10;
    [SerializeField] public int _Rows = 10;

    public static CreateMap Instance;


    private void Awake()
    {        
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            CreateFirstMap();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateFirstMap()
    {
        _Grid = new GameObject[_Cols, _Rows];
        for (int col = 0; col < _Cols; col++)
        {
            for (int row = 0; row < _Rows; row++)
            {
                Vector3 pos = new Vector3(col + 0.5f, row + 0.5f, 0);
                GameObject clone = Instantiate(prefab, pos, Quaternion.identity);
                _Grid[col, row] = clone;

            }
        }
    }
    public void ChangeSizeMap(int newCols, int newRows)
    {
        if (newCols < _Cols || newRows < _Rows)
        {
            ReductMap(newCols, newRows);
        }
        else if (newCols > _Cols || newRows > _Rows )
        {
            ExpendMap(newCols, newRows);
        }
        else
        {
            Debug.Log("same size");
        }
        _Cols = newCols;
        _Rows = newRows;
    }

    private void ReductMap(int newCols, int newRows)
    {
        for (int col = 0; col < _Cols; col++)
        {
            for (int rows = 0; rows < _Rows; rows++)
            {
                if (col > newCols || rows > newRows)
                {
                    _Grid[col, rows].SetActive(false);
                }
            }
        }
    }

    private void ExpendMap(int newCols, int newRows)
    {
        for (int col = 0; col < newCols; col++)
        {
            for (int row = 0; row < newRows; row++)
            {
                if (col >= _Cols || row >= _Rows)
                {
                    _Grid[col, row].SetActive(true);
                }
            }
        }
    }
    
}
