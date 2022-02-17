using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GestionCellule : MonoBehaviour
{
    private int _Col;
    private int _Row;

    private int _SizeCol = 100;
    private int _SizeRow = 100;

    private int _Compt_cellule;


    public bool[,] m_celluleTemp;

    [SerializeField] private int _Vitesse = 5;

    public int m_compt_simulation = 0;

    public GameObject m_img_btn_play;
    public GameObject m_btn_bordure_infini;
    public TextMeshProUGUI m_textCompteur;


    public bool m_start = false;
    public bool m_map_infini = true;
    public bool m_one_updtate = false;

    // Start is called before the first frame update
    void Start()
    {
        _Col = 150;
        _Row = 150; 
        m_celluleTemp = new bool[_Col, _Row];

        _SizeCol = GestionMap.Instance.m_colsSlider;
        _SizeRow = GestionMap.Instance.m_rowsSlider;
        Debug.Log($"taille map col <color=yellow>" + _SizeCol + "</color>");
        Debug.Log($"taille map Row <color=purple>" + _SizeRow + "</color>");
    }

    // Update is called once per frame
    void Update()
    {
        _SizeCol = GestionMap.Instance.m_colsSlider;
        _SizeRow = GestionMap.Instance.m_rowsSlider;


        if (m_start == true)
        {
            if (m_one_updtate == true)
            {
                m_start = false;
                m_one_updtate = false;
            }
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = _Vitesse;
            m_compt_simulation++;
            m_textCompteur.GetComponent<TextMeshProUGUI>().text = m_compt_simulation.ToString();

            m_celluleTemp = new bool[_Col, _Row];

            

            if (m_map_infini == true)
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
                    if (m_celluleTemp[x, y] == false)
                    {
                        GestionMap.Instance.m_grid[x, y].GetComponent<SpriteRenderer>().color = Color.black;
                    }
                    else
                    {
                        GestionMap.Instance.m_grid[x, y].GetComponent<SpriteRenderer>().color = Color.white;
                    }
                    
                }
            }

        }else 
        {
            Application.targetFrameRate = 300;
            
        }
    }

    // Color btn run game and run game 
    public void RunGame()
    {
        m_start = true;
        m_img_btn_play.GetComponent<Image>().color = Color.green;
    }

    // stop game and color btn
    public void StopGame()
    {
        m_start = false;
        m_img_btn_play.GetComponent<Image>().color = new Color32(0, 60, 0, 255);
    }

    // avance pas a pas 
    public void OneUpdate()
    {
        m_one_updtate = true;
        m_start = true;
    }

    // Vitesse X1
    public void Vitesse1()
    {
        _Vitesse = 10;
    }

    // Vitesse X2
    public void Vitesse2()
    {
        _Vitesse = 15;
    }

    // Vitesse X4
    public void Vitesse4()
    {
        _Vitesse = 20;
    }

    // Change mode bordure 
    public void IfiniBordureBtn()
    {
        if (m_map_infini == false)
        {
            m_map_infini = true;
            m_btn_bordure_infini.GetComponent<Image>().color = Color.red;

        }
        else
        {
            m_map_infini = false;
            m_btn_bordure_infini.GetComponent<Image>().color = Color.blue;
        }

    }




    private void CheckVoisinInfini()
    {
        for (int col = 0; col < _Col; col++)
        {
            for (int row = 0; row < _Row; row++)
            {
                _Compt_cellule = 0;

                //compte voisin X
                if (col > 0)
                {
                    if (GestionMap.Instance.m_grid[col - 1, row].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }


                }
                if (col < _Col - 1)
                {
                    if (GestionMap.Instance.m_grid[col + 1, row].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }


                //Compt voisin Y
                if (row > 0)
                {
                    if (GestionMap.Instance.m_grid[col, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (row < _Row - 1)
                {
                    if (GestionMap.Instance.m_grid[col, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }

                // Compte voisin XY

                if (col > 0 && row > 0)
                {
                    if (GestionMap.Instance.m_grid[col - 1, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col < _Col - 1 && row < _Row - 1)
                {
                    if (GestionMap.Instance.m_grid[col + 1, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col > 0 && row < _Row - 1)
                {
                    if (GestionMap.Instance.m_grid[col - 1, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col < _Col - 1 && row > 0)
                {
                    if (GestionMap.Instance.m_grid[col + 1, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }

                RegleVoisin(col, row);

            }
        }
    }

    private void RegleVoisin(int col, int row)
    {
        if (_Compt_cellule == 3)
        {
            m_celluleTemp[col, row] = true;

        }
        else if (_Compt_cellule < 2 || _Compt_cellule > 3)
        {
            m_celluleTemp[col, row] = false;

        }
        else
        {
            if (GestionMap.Instance.m_grid[col, row].GetComponent<SpriteRenderer>().color == Color.black)
            {
                m_celluleTemp[col, row] = false;
            }
            else
            {
                m_celluleTemp[col, row] = true;
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
                    if (GestionMap.Instance.m_grid[col - 1, row].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }


                }

                if (col < _Col - 26)
                {
                    if (GestionMap.Instance.m_grid[col + 1, row].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }


                //Compt voisin Y
                if (row > 25)
                {
                    if (GestionMap.Instance.m_grid[col, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (row < _Row - 26)
                {
                    if (GestionMap.Instance.m_grid[col, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }

                // Compte voisin XY

                if (col > 25 && row > 25)
                {
                    if (GestionMap.Instance.m_grid[col - 1, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col < _Col - 26 && row < _Row - 26)
                {
                    if (GestionMap.Instance.m_grid[col + 1, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col > 25 && row < _Row - 26)
                {
                    if (GestionMap.Instance.m_grid[col - 1, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Compt_cellule++;
                    }
                }
                if (col < _Col - 26 && row > 25)
                {
                    if (GestionMap.Instance.m_grid[col + 1, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
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
            if (GestionMap.Instance.m_grid[125, row    ].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance.m_grid[125, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance.m_grid[125, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
        }
        if (col == 125 && row >= 26 && row <= 125)
        {
            if (GestionMap.Instance.m_grid[26, row    ].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance.m_grid[26, row + 1].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance.m_grid[26, row - 1].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
        }
        if (row == 26 && col >= 26 && col < 125)
        {
            if (GestionMap.Instance.m_grid[col, _SizeRow + 26    ].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance.m_grid[col + 1, _SizeRow + 26].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance.m_grid[col - 1, _SizeRow + 26].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
        }
        if (row == _SizeRow + 25 && col >= 26 && col < 125)
        {
            if (GestionMap.Instance.m_grid[col, 26    ].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance.m_grid[col + 1, 26].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
            if (GestionMap.Instance.m_grid[col - 1, 26].GetComponent<SpriteRenderer>().color == Color.white)
            { _Compt_cellule++; }
        }
    }
    private void ComptVoisin(int col, int row)
    {

        if (_Compt_cellule == 3)
        {
            m_celluleTemp[col, row] = true;

        }
        else if (_Compt_cellule < 2 || _Compt_cellule > 3)
        {
            m_celluleTemp[col, row] = false;

        }
        else
        {
            if (GestionMap.Instance.m_grid[col, row].GetComponent<SpriteRenderer>().color == Color.black)
            {
                m_celluleTemp[col, row] = false;
            }
            else
            {
                m_celluleTemp[col, row] = true;
            }
        }
    }
}
