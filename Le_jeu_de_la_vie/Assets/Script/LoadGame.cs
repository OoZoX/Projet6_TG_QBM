using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO;


public class LoadGame : MonoBehaviour
{
    [SerializeField] public Button m_button_load;
    [SerializeField] private TMP_InputField _NameFileLoad;
    private string _Path;
    private string _Line;
    private string _LineTemp;
    private int _ColTxt;
    private int y;

    void Start()
    {
        m_button_load = GetComponent<Button>();
        m_button_load.onClick.AddListener(TaskOnClickLoad);
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

            if(int.TryParse(_Line, out _ColTxt))
            {
                _LineTemp = sr.ReadLine();

                if (int.TryParse(_LineTemp, out y))
                {
                    GestionMap.Instance.ChangeSizeMap(_ColTxt, y);

                    UpdateMap(_ColTxt, y, sr);
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
    // Recupere le path
    private StreamReader GetPath()
    {
        _Path = "./Assets/save/" + _NameFileLoad.text + ".txt";
        _Path = Path.GetFullPath(_Path);

        StreamReader sr = new StreamReader(_Path);

        return sr;
    }

    // Met a jour la map avec le fichier
    private void UpdateMap(int x, int y, StreamReader sr)
    {
        for (int i = 0; i < x; i++)
        {
            _Line = sr.ReadLine();

            for (int j = 0; j < y; j++)
            {
                if (_Line[j].ToString() == "1")
                {
                    GestionMap.Instance.m_grid[i, j].GetComponent<SpriteRenderer>().color = Color.white;
                }
                else if (_Line[j].ToString() == "0")
                {
                    GestionMap.Instance.m_grid[i, j].GetComponent<SpriteRenderer>().color = Color.black;
                }
                else
                {
                    Debug.Log("Probleme check 1 - 0 ");
                }
            }
        }
    }
}
