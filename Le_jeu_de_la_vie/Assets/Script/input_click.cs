using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_click : MonoBehaviour
{
    private Vector3 _Pos_souri;
    private Camera camera;
    public Vector3 offset = new Vector3(0, 1, 0);


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _Pos_souri = camera.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(_Pos_souri);

        }
    }
}
