using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO;
using System.Threading.Tasks;

public class LoadGame : MonoBehaviour
{
    [SerializeField] public Button button_load;
    [SerializeField] private TMP_InputField _NameFileLoad;
    private string path;
    private string _Line;
    private string _LineTemp;
    private int x;
    private int y;

    void Start()
    {
        button_load = GetComponent<Button>();
        button_load.onClick.AddListener(TaskOnClickLoad);
    }

    private void TaskOnClickLoad()
    {
        Debug.Log("button load");
        LoadMap();
    }

    private void LoadMap()
    {
        try
        {
            StreamReader sr = GetPath();
             _Line = sr.ReadLine();

            if(int.TryParse(_Line, out x))
            {
                _LineTemp = sr.ReadLine();

                if (int.TryParse(_LineTemp, out y))
                {
                    GestionMap.Instance.ChangeSizeMap(x, y);

                    UpdateMap(x, y, sr);
                }
                else
                {
                    Debug.Log("Probleme parse y");
                }
            }
            else
            {
                Debug.Log("Probleme parse x");
            }
        }
        finally
        {
            Debug.Log("probleme load map");
        }
    }

    private StreamReader GetPath()
    {
        path = "./Assets/save/" + _NameFileLoad.text + ".txt";
        path = Path.GetFullPath(path);

        StreamReader sr = new StreamReader(path);

        return sr;
    }

    private void UpdateMap(int x, int y, StreamReader sr)
    {
        for (int i = 0; i < x; i++)
        {
            _Line = sr.ReadLine();

            for (int j = 0; j < y; j++)
            {
                if (_Line[j].ToString() == "1")
                {
                    GestionMap.Instance._Grid[i, j].GetComponent<SpriteRenderer>().color = Color.white;
                }
                else if (_Line[j].ToString() == "0")
                {
                    GestionMap.Instance._Grid[i, j].GetComponent<SpriteRenderer>().color = Color.black;
                }
                else
                {
                    Debug.Log("Probleme check 1 - 0 ");
                }
            }
        }
    }
}
