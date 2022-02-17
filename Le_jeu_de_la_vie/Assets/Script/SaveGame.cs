using System.IO;
using UnityEngine.UI;
using UnityEngine;
using TMPro;



public class SaveGame : MonoBehaviour
{

    [SerializeField] public Button m_button_save;
    [SerializeField] private TMP_InputField _NameFile;
    private string _Path;
    private string _Line;
    private string _PathChemin;

    private void Start()
    {

        m_button_save = GetComponent<Button>();


        m_button_save.onClick.AddListener(TaskOnClickSave);

    }


    private void TaskOnClickSave()
    {
        try
        {
            _Path = "./Assets/save/" + _NameFile.text + ".txt";
            _Path = Path.GetFullPath(_Path);
            Debug.Log(_Path);
            StreamWriter file = new StreamWriter(_Path);
            file.WriteLine(GestionMap.Instance.m_cols);
            file.WriteLine(GestionMap.Instance.m_rows);
            for (int i = 0; i < GestionMap.Instance.m_cols; i++)
            {
                _Line = "";
                for (int j = 0; j < GestionMap.Instance.m_rows; j++)
                {
                    if (GestionMap.Instance.m_grid[i,j].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        _Line += "1";
                    }
                    else
                    {
                        _Line += "0";
                    }
                }
                file.WriteLine(_Line);
            }
            file.Close();
            try
            {
                _PathChemin = "./Assets/save/chemin.txt";
                _PathChemin = Path.GetFullPath(_PathChemin);
                //string fileChemin = Path.GetFileName(pathChemin);
                using StreamWriter sw = new StreamWriter(_PathChemin, append: true);
                sw.WriteLine(_NameFile.text);
                sw.Close();
            }

            finally
            {
                Debug.Log("probleme save name file");
            }

        }
        finally
        {
            Debug.Log("probleme save !");
        }
    }
}
