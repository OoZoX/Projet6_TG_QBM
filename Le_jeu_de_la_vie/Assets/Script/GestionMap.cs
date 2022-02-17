using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class GestionMap : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    public GameObject[,] _Grid;

    [SerializeField] public int _Cols = 150;
    [SerializeField] public int _Rows = 150;

    public int _ColsSlider = 100;
    public int _RowsSlider = 100;

    public static GestionMap Instance;


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
        _Grid = new GameObject[150, 150];
        for (int col = 0; col < 150; col++)
        {
            for (int row = 0; row < 150; row++)
            {
                Vector3 pos = new Vector3(col + 0.5f, row + 0.5f, 0);
                GameObject clone = Instantiate(prefab, pos, Quaternion.identity);
                _Grid[col, row] = clone;

            }
        }
        _Cols = 150;
        _Rows = 150;

        for (int col = 0; col < _Cols; col++)
        {
            for (int rows = 0; rows < _Rows; rows++)
            {
                if (col > 125 || rows > 125 || col < 26 || rows < 26)
                {
                    _Grid[col, rows].SetActive(false);
                }
            }
        }

        _Cols = 100;
        _Rows = 100;

    }
    public void ChangeSizeMap(int newCols, int newRows)
    {
        
        if (newCols < _Cols || newRows < _Rows)
        {

            ReductMap(newCols, newRows);
        }
        if (newCols > _Cols || newRows > _Rows )
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
                if (col >= newCols || rows >= newRows)
                {
                    _Grid[col +26, rows +26].SetActive(false);
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
                    _Grid[col +26, row +26].SetActive(true);
                }
            }
        }
    }
    
}
