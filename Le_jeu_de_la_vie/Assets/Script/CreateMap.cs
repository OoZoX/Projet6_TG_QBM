using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    public GameObject[,] _Grid;
    


    [SerializeField] public int _ColX = 10;
    [SerializeField] public int _ColY = 10;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update_Rows(int new_ColX)
    {
        _ColX = new_ColX;
    }

    public void Update_Columns(int new_ColY)
    {
        _ColX = new_ColY;
    }

}
