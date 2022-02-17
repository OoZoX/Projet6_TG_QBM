using UnityEngine;

public class Input : MonoBehaviour
{
    private Vector3 _Pos_souri;
    private Camera _Camera;
    public Vector3 m_offset = new Vector3(0, 1, 0);
    private GameObject _ExClick = null;


    // Start is called before the first frame update
    void Start()
    {
        _Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // recupere pos souris et color carre 
        if (UnityEngine.Input.GetMouseButton(0))
        {
            _Pos_souri = _Camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            Debug.Log($"<color=yellow>" + _Pos_souri.x + "</color> <color=blue>" + _Pos_souri.y + "</color>");
            if (_Pos_souri.x < 25 || _Pos_souri.y < 25 || _Pos_souri.x > GestionMap.Instance.m_cols +26 || _Pos_souri.y > GestionMap.Instance.m_rows +26)
            {
                Debug.Log("out of range");
            }
            else
            {
                if (_ExClick != null)
                {
                    if (_ExClick != GestionMap.Instance.m_grid[(int)_Pos_souri.x, (int)_Pos_souri.y])
                    {
                        if (GestionMap.Instance.m_grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color == Color.white)
                        {
                            GestionMap.Instance.m_grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                        else
                        {
                            GestionMap.Instance.m_grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        _ExClick = GestionMap.Instance.m_grid[(int)_Pos_souri.x, (int)_Pos_souri.y];
                    }
                }
                else
                {
                    _ExClick = GestionMap.Instance.m_grid[(int)_Pos_souri.x, (int)_Pos_souri.y];
                    if (GestionMap.Instance.m_grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        GestionMap.Instance.m_grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color = Color.black;
                    }
                    else
                    {
                        GestionMap.Instance.m_grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color = Color.white;
                    }
                }
            }
            
        }
    }
}
