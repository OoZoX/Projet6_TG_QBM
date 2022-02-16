using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GestionCellule : MonoBehaviour
{
    private int _ColX;
    private int _ColY;
    private int _Compt_cellule;
    public bool[,] _CelluleTemp;
    [SerializeField] private int vitesse = 30;


    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {


        _ColX = 150; // CreateMap.Instance._Cols;
        _ColY = 150; //CreateMap.Instance._Rows;
        _CelluleTemp = new bool[_ColX, _ColY];


    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            Application.targetFrameRate = vitesse;

            for (int x = 0; x < _ColX; x++)
            {
                for (int y = 0; y < _ColY; y++)
                {
                    _Compt_cellule = 0;
                    //_CelluleTemp = new GameObject[,] {};
                    //compte voisin X
                    if (x > 0)
                    {
                        if (CreateMap.Instance._Grid[x - 1, y].GetComponent<SpriteRenderer>().color == Color.white)
                        {
                            _Compt_cellule++;
                        }


                    }
                    if (x < _ColX - 1)
                    {
                        if (CreateMap.Instance._Grid[x + 1, y].GetComponent<SpriteRenderer>().color == Color.white)
                        {
                            _Compt_cellule++;
                        }
                    }
                    

                    //Compt voisin Y
                    if (y > 0)
                    {
                        if (CreateMap.Instance._Grid[x, y - 1].GetComponent<SpriteRenderer>().color == Color.white)
                        {
                            _Compt_cellule++;
                        }
                    }
                    if (y < _ColY - 1)
                    {
                        if (CreateMap.Instance._Grid[x, y + 1].GetComponent<SpriteRenderer>().color == Color.white)
                        {
                            _Compt_cellule++;
                        }
                    }

                    // Compte voisin XY

                    if (x > 0 && y > 0)
                    {
                        if (CreateMap.Instance._Grid[x -1, y - 1].GetComponent<SpriteRenderer>().color == Color.white)
                        {
                            _Compt_cellule++;
                        }
                    }
                    if (x < _ColX -1 && y < _ColY - 1)
                    {
                        if (CreateMap.Instance._Grid[x +1, y + 1].GetComponent<SpriteRenderer>().color == Color.white)
                        {
                            _Compt_cellule++;
                        }
                    }
                    if (x > 0 && y < _ColY - 1)
                    {
                        if (CreateMap.Instance._Grid[x - 1, y + 1].GetComponent<SpriteRenderer>().color == Color.white)
                        {
                            _Compt_cellule++;
                        }
                    }
                    if (x < _ColX - 1 && y > 0)
                    {
                        if (CreateMap.Instance._Grid[x + 1, y - 1].GetComponent<SpriteRenderer>().color == Color.white)
                        {
                            _Compt_cellule++;
                        }
                    }

                    if (_Compt_cellule == 3)
                    {
                        _CelluleTemp[x, y] = true;
                        
                    }
                    else if (_Compt_cellule < 2 || _Compt_cellule > 3)
                    {
                        _CelluleTemp[x, y] = false;
                        
                    }
                    else
                    {
                        if (CreateMap.Instance._Grid[x,y].GetComponent<SpriteRenderer>().color == Color.black)
                        {
                            _CelluleTemp[x, y] = false;
                        }
                        else
                        {
                            _CelluleTemp[x, y] = true;
                        }
                    }

                }
            }
            for (int x = 0; x < _ColX; x++)
            {
                for (int y = 0; y < _ColY; y++)
                {
                    if (_CelluleTemp[x, y] == false)
                    {
                        CreateMap.Instance._Grid[x, y].GetComponent<SpriteRenderer>().color = Color.black;
                    }
                    else
                    {
                        CreateMap.Instance._Grid[x, y].GetComponent<SpriteRenderer>().color = Color.white;
                    }
                    
                }
            }

        }else 
        {
            Application.targetFrameRate = 300;
        }
    }

    public void RunGame()
    {
        start = true;
    }

    public void StopGame()
    {
        start = false;
    }
}
