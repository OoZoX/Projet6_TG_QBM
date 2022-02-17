using UnityEngine;


public class GestionMap : MonoBehaviour
{
    [SerializeField]
    public GameObject m_prefab;

    public GameObject[,] m_grid;

    [SerializeField] public int m_cols = 150;
    [SerializeField] public int m_rows = 150;

    public int m_colsSlider = 100;
    public int m_rowsSlider = 100;

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
        m_grid = new GameObject[150, 150];
        for (int col = 0; col < 150; col++)
        {
            for (int row = 0; row < 150; row++)
            {
                Vector3 pos = new Vector3(col + 0.5f, row + 0.5f, 0);
                GameObject clone = Instantiate(m_prefab, pos, Quaternion.identity);
                m_grid[col, row] = clone;

            }
        }
        m_cols = 150;
        m_rows = 150;

        for (int col = 0; col < m_cols; col++)
        {
            for (int rows = 0; rows < m_rows; rows++)
            {
                if (col > 125 || rows > 125 || col < 26 || rows < 26)
                {
                    m_grid[col, rows].SetActive(false);
                }
            }
        }

        m_cols = 100;
        m_rows = 100;

    }
    public void ChangeSizeMap(int newCols, int newRows)
    {
        
        if (newCols < m_cols || newRows < m_rows)
        {

            ReductMap(newCols, newRows);
        }
        if (newCols > m_cols || newRows > m_rows )
        {
            ExpendMap(newCols, newRows);
        }
        else
        {
            Debug.Log("same size");
        }
        m_cols = newCols;
        m_rows = newRows;
    }

    private void ReductMap(int newCols, int newRows)
    {
        for (int col = 0; col < m_cols; col++)
        {
            for (int rows = 0; rows < m_rows; rows++)
            {
                if (col >= newCols || rows >= newRows)
                {
                    m_grid[col +26, rows +26].SetActive(false);
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
                if (col >= m_cols || row >= m_rows)
                {
                    m_grid[col +26, row +26].SetActive(true);
                }
            }
        }
    }

    public void CleanMap()
    {
        for (int col = 0; col < m_cols; col++)
        {
            for (int rows = 0; rows < m_rows; rows++)
            {
                if (col > 125 || rows > 125 || col < 26 || rows < 26)
                {
                    m_grid[col, rows].SetActive(false);
                }
                else
                {
                    m_grid[col, rows].GetComponent<SpriteRenderer>().color = Color.black;
                }
            }
        }
        ChangeSizeMap(100,100);
    }
    
}
