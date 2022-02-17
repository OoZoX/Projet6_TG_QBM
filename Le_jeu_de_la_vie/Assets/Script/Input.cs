using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{
    private Vector3 _Pos_souri;
    private Camera camera;
    public Vector3 offset = new Vector3(0, 1, 0);
    private GameObject _exClick = null;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (UnityEngine.Input.GetMouseButton(0))
        {
            _Pos_souri = camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            Debug.Log($"<color=yellow>" + _Pos_souri.x + "</color> <color=blue>" + _Pos_souri.y + "</color>");
            if (_Pos_souri.x < 25 || _Pos_souri.y < 25 || _Pos_souri.x > GestionMap.Instance._Cols +26 || _Pos_souri.y > GestionMap.Instance._Rows +26)
            {
                Debug.Log("out of range");
            }
            else
            {
                if (_exClick != null)
                {
                    if (_exClick != GestionMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y])
                    {
                        if (GestionMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color == Color.white)
                        {
                            GestionMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color = Color.black;
                        }
                        else
                        {
                            GestionMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color = Color.white;
                        }
                        _exClick = GestionMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y];
                    }
                }
                else
                {
                    _exClick = GestionMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y];
                    if (GestionMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        GestionMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color = Color.black;
                    }
                    else
                    {
                        GestionMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color = Color.white;
                    }
                }
            }
            
        }
    }
}
