using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestionCellule : MonoBehaviour
{
    private int _ColX;
    private int _ColY;
    private int _Compt_cellule;
    public GameObject[,] _CelluleTemp;

    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        _ColX = CreateMap.Instance._ColX;
        _ColY = CreateMap.Instance._ColY;
        _CelluleTemp = new GameObject[_ColX, _ColY];
        

    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            Application.targetFrameRate = 2;

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
                        CreateMap.Instance._Grid[x, y].GetComponent<SpriteRenderer>().color = Color.white;
                        _CelluleTemp[x, y] = CreateMap.Instance._Grid[x, y];
                    }
                    else if (_Compt_cellule < 2 || _Compt_cellule > 3)
                    {
                        CreateMap.Instance._Grid[x, y].GetComponent<SpriteRenderer>().color = Color.black;
                        _CelluleTemp[x, y] = CreateMap.Instance._Grid[x, y];
                    }
                    else
                    {
                        _CelluleTemp[x, y] = CreateMap.Instance._Grid[x, y];
                    }

                }
            }

            CreateMap.Instance._Grid = _CelluleTemp;

        }else 
        {
            Application.targetFrameRate = 100;
        }
    }
}
