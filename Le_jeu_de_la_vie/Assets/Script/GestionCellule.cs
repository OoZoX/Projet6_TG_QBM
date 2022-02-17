using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class GestionCellule : MonoBehaviour
{
    private int _Col;
    private int _Row;

    private int _SizeCol = 100;
    private int _SizeRow = 100;

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
        _Col = 150; // CreateMap.Instance._Cols;
        _Row = 150; //CreateMap.Instance._Rows;
        _CelluleTemp = new bool[_Col, _Row];

        _SizeCol = GestionMap.Instance._ColsSlider;
        _SizeRow = GestionMap.Instance._RowsSlider;
        Debug.Log($"taille map col <color=yellow>" + _SizeCol + "</color>");
        Debug.Log($"taille map Row <color=purple>" + _SizeRow + "</color>");
    }

    // Update is called once per frame
    void Update()
    {
        _SizeCol = GestionMap.Instance._ColsSlider;
        _SizeRow = GestionMap.Instance._RowsSlider;


        if (start == true)
        {
            if (one_updtate == true)
            {
                start = false;
                one_updtate = false;
            }
            compt_simulation++;
            textCompteur.GetComponent<TextMeshProUGUI>().text = compt_simulation.ToString();

            _CelluleTemp = new bool[_Col, _Row];

            Application.targetFrameRate = vitesse;

            if (map_infini == true)
            {
                CheckVoisinInfini();
            }
            else
            {
                CheckVoisinBordure();
            }


            
            for (int x = 0; x < _Col; x++)
            {
                for (int y = 0; y < _Row; y++)
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
        for (int col = 0; col < _Col; col++)
        {
            for (int row = 0; row < _Row; row++)
            {
                _Compt_cellule = 0;
                //_CelluleTemp = new GameObject[,] {};
                //compte voisin X
                if (col > 0)
                {
                    if (GestionMap.Instance._Grid[col - 1, row].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }


                }
                if (col < _Col - 1)
                {
                    if (GestionMap.Instance._Grid[col + 1, row].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }


                //Compt voisin Y
                if (row > 0)
                {
                    if (GestionMap.Instance._Grid[col, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (row < _Row - 1)
                {
                    if (GestionMap.Instance._Grid[col, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }

                // Compte voisin XY

                if (col > 0 && row > 0)
                {
                    if (GestionMap.Instance._Grid[col - 1, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col < _Col - 1 && row < _Row - 1)
                {
                    if (GestionMap.Instance._Grid[col + 1, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col > 0 && row < _Row - 1)
                {
                    if (GestionMap.Instance._Grid[col - 1, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col < _Col - 1 && row > 0)
                {
                    if (GestionMap.Instance._Grid[col + 1, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }

                if (_Compt_cellule == 3)
                {
                    _CelluleTemp[col, row] = true;

                }
                else if (_Compt_cellule < 2 || _Compt_cellule > 3)
                {
                    _CelluleTemp[col, row] = false;

                }
                else
                {
                    if (GestionMap.Instance._Grid[col, row].GetComponent<SpriteRenderer>().color == Color.black)
                    {
                        _CelluleTemp[col, row] = false;
                    }
                    else
                    {
                        _CelluleTemp[col, row] = true;
                    }
                }

            }
        }
    }

    private void CheckVoisinBordure()
    {
        for (int col = 0; col < _Col; col++)
        {
            for (int row = 0; row < _Row; row++)
            {
                _Compt_cellule = 0;

                //compte voisin X
                if (col > 25)
                {
                    if (GestionMap.Instance._Grid[col - 1, row].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }


                }

                if (col < _Col - 26)
                {
                    if (GestionMap.Instance._Grid[col + 1, row].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }


                //Compt voisin Y
                if (row > 25)
                {
                    if (GestionMap.Instance._Grid[col, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (row < _Row - 26)
                {
                    if (GestionMap.Instance._Grid[col, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }

                // Compte voisin XY

                if (col > 25 && row > 25)
                {
                    if (GestionMap.Instance._Grid[col - 1, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col < _Col - 26 && row < _Row - 26)
                {
                    if (GestionMap.Instance._Grid[col + 1, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col > 25 && row < _Row - 26)
                {
                    if (GestionMap.Instance._Grid[col - 1, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col < _Col - 26 && row > 25)
                {
                    if (GestionMap.Instance._Grid[col + 1, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }




                AjoutVoisinMiroire(col, row);

                ComptVoisin(col, row);



                    /*
                    //coin bas gauche
                    if (y < 25 && x < 25)
                    {
                        _CelluleTemp[_SizeCol - (25 - x), _SizeRow - (25 - y)] = true;
                        _CelluleTemp[x, y] = false;
                    }

                    //coin bas droite
                    if (x > _SizeCol && y < 25)
                    {
                        _CelluleTemp[25 + (_SizeCol - x), _SizeRow - (25 - y)] = true;
                        _CelluleTemp[x, y] = false;
                    }
                    
                    //coin haut gauche
                    if(x < 25 && y > _SizeRow)
                    {
                        
                    }
                    */
                }

            }
        }

    private void AjoutVoisinMiroire(int col, int row)
    {
        if (col == 26 && row >= 26 && row <= 125)
        {
            if (GestionMap.Instance._Grid[125, row    ].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance._Grid[125, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance._Grid[125, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
        }
        if (col == 125 && row >= 26 && row <= 125)
        {
            if (GestionMap.Instance._Grid[26, row    ].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance._Grid[26, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance._Grid[26, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
        }
        if (row == 26 && col >= 26 && col < 125)
        {
            if (GestionMap.Instance._Grid[col, _SizeRow + 26    ].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance._Grid[col + 1, _SizeRow + 26].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance._Grid[col - 1, _SizeRow + 26].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
        }
        if (row == _SizeRow + 25 && col >= 26 && col < 125)
        {
            if (GestionMap.Instance._Grid[col, 26    ].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance._Grid[col + 1, 26].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance._Grid[col - 1, 26].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
        }
    }
    private void ComptVoisin(int col, int row)
    {

        if (_Compt_cellule == 3)
        {
            _CelluleTemp[col, row] = true;

        }
        else if (_Compt_cellule < 2 || _Compt_cellule > 3)
        {
            _CelluleTemp[col, row] = false;

        }
        else
        {
            if (GestionMap.Instance._Grid[col, row].GetComponent<SpriteRenderer>().color == Color.black)
            {
                _CelluleTemp[col, row] = false;
            }
            else
            {
                _CelluleTemp[col, row] = true;
            }
        }
    }
    private void CalculeMiroire(int col, int row)
    {

        // bordure gauche
        if (col < 25)
        {
            _CelluleTemp[_SizeCol +25 - (25 - col), row] = true;

            Debug.Log($"<color=red>gauche</color>");
        }

        // border bas
        else if (row < 25)
        {
            _CelluleTemp[col, _SizeRow +25 - (25 - row)] = true;

            Debug.Log($"<color=blue>bas</color>");
        }

        //border droite 
        else if (col > _SizeCol +25)
        {
            _CelluleTemp[25 + (col - _SizeCol), row] = true;

            Debug.Log($"<color=green>droite</color>");
        }

        //border haut
        else if (row > _SizeRow +25)
        {
            _CelluleTemp[col, 25 + (row - _SizeRow)] = true;

            Debug.Log($"<color=pink>haut</color>");
        }
    }
}
