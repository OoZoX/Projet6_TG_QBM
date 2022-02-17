using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class GestionCellule : MonoBehaviour
{
    private int _ColX;
    private int _ColY;
    private int _Compt_cellule;


    public bool[,] _CelluleTemp;

    [SerializeField] private int vitesse = 30;

    public int compt_simulation = 0;

    public GameObject img_btn_play;
    public GameObject btn_bordure_infini;
    public TextMeshProUGUI textCompteur;


    public bool start = false;
    public bool map_infini = true;
    public bool one_updtate = false;

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
            if (one_updtate == true)
            {
                start = false;
                one_updtate = false;
            }
            compt_simulation++;
            textCompteur.GetComponent<TextMeshProUGUI>().text = compt_simulation.ToString();


            Application.targetFrameRate = vitesse;

            CheckVoisinInfini();


            for (int x = 0; x < _ColX; x++)
            {
                for (int y = 0; y < _ColY; y++)
                {
                    if (_CelluleTemp[x, y] == false)
                    {
                        GestionMap.Instance._Grid[x, y].GetComponent<SpriteRenderer>().color = Color.black;
                    }
                    else
                    {
                        GestionMap.Instance._Grid[x, y].GetComponent<SpriteRenderer>().color = Color.white;
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
        img_btn_play.GetComponent<Image>().color = Color.green;
    }

    public void StopGame()
    {
        start = false;
        img_btn_play.GetComponent<Image>().color = new Color32(0, 60, 0, 255);
    }

    public void OneUpdate()
    {
        one_updtate = true;
        start = true;
    }
    public void IfiniBordureBtn()
    {
        if (map_infini == false)
        {
            map_infini = true;
            btn_bordure_infini.GetComponent<Image>().color = Color.red;

        }
        else
        {
            map_infini = false;
            btn_bordure_infini.GetComponent<Image>().color = Color.blue;
        }

    }




    private void CheckVoisinInfini()
    {
        for (int x = 0; x < _ColX; x++)
        {
            for (int y = 0; y < _ColY; y++)
            {
                _Compt_cellule = 0;
                //_CelluleTemp = new GameObject[,] {};
                //compte voisin X
                if (x > 0)
                {
                    if (GestionMap.Instance._Grid[x - 1, y].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }


                }
                if (x < _ColX - 1)
                {
                    if (GestionMap.Instance._Grid[x + 1, y].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }


                //Compt voisin Y
                if (y > 0)
                {
                    if (GestionMap.Instance._Grid[x, y - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (y < _ColY - 1)
                {
                    if (GestionMap.Instance._Grid[x, y + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }

                // Compte voisin XY

                if (x > 0 && y > 0)
                {
                    if (GestionMap.Instance._Grid[x - 1, y - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (x < _ColX - 1 && y < _ColY - 1)
                {
                    if (GestionMap.Instance._Grid[x + 1, y + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (x > 0 && y < _ColY - 1)
                {
                    if (GestionMap.Instance._Grid[x - 1, y + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (x < _ColX - 1 && y > 0)
                {
                    if (GestionMap.Instance._Grid[x + 1, y - 1].GetComponent<SpriteRenderer>().color == Color.white)
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
                    if (GestionMap.Instance._Grid[x, y].GetComponent<SpriteRenderer>().color == Color.black)
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
    }

    private void CheckVoisinBordure()
    {
        for (int x = 0; x < _ColX; x++)
        {
            for (int y = 0; y < _ColY; y++)
            {
                _Compt_cellule = 0;
                //_CelluleTemp = new GameObject[,] {};
                //compte voisin X
                if (x > 25)
                {
                    if (GestionMap.Instance._Grid[x - 1, y].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }


                }
                if (x < _ColX - 26)
                {
                    if (GestionMap.Instance._Grid[x + 1, y].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }


                //Compt voisin Y
                if (y > 25)
                {
                    if (GestionMap.Instance._Grid[x, y - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (y < _ColY - 26)
                {
                    if (GestionMap.Instance._Grid[x, y + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }

                // Compte voisin XY

                if (x > 25 && y > 25)
                {
                    if (GestionMap.Instance._Grid[x - 1, y - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (x < _ColX - 26 && y < _ColY - 26)
                {
                    if (GestionMap.Instance._Grid[x + 1, y + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (x > 25 && y < _ColY - 26)
                {
                    if (GestionMap.Instance._Grid[x - 1, y + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (x < _ColX - 26 && y > 25)
                {
                    if (GestionMap.Instance._Grid[x + 1, y - 1].GetComponent<SpriteRenderer>().color == Color.white)
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
                    if (GestionMap.Instance._Grid[x, y].GetComponent<SpriteRenderer>().color == Color.black)
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
    }
}
