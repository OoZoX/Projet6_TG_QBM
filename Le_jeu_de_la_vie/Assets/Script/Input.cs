using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{
    private Vector3 _Pos_souri;
    private Camera camera;
    public Vector3 offset = new Vector3(0, 1, 0);

    //public GameObject[,] Map = gener_map.Instance._Grid;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            _Pos_souri = camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

            Debug.Log(_Pos_souri);
            Debug.Log((int)_Pos_souri.x);
            Debug.Log((int)_Pos_souri.y);

            if (CreateMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color == Color.white)
            {
                CreateMap.Instance._Grid[(int)_Pos_souri.x, (int)_Pos_souri.y].GetComponent<SpriteRenderer>().color = Color.black;
            }
            else
            {
                CreateMap.Instance._Grid[(int)_Pos_souri.x , (int)_Pos_souri.y ].GetComponent<SpriteRenderer>().color = Color.white;
            }
            
            //Debug.Log(color);
        }
    }
}
