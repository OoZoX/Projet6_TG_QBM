using System.IO;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
//using System.Text.Json;
//using System.Text.Json.Serialization;


public class SaveGame : MonoBehaviour
{

    [SerializeField] public Button button_save;
    [SerializeField] private TMP_InputField _NameFile;
    private string path;
    private string line;
    private string pathChemin;
    private string pathFileName;

    private void Start()
    {

        button_save = GetComponent<Button>();


        button_save.onClick.AddListener(TaskOnClickSave);

    }


    private void TaskOnClickSave()
    {
        try
        {
            path = "./Assets/save/" + _NameFile.text + ".txt";
            path = Path.GetFullPath(path);
            Debug.Log(path);
            StreamWriter file = new StreamWriter(path);
            file.WriteLine(GestionMap.Instance._Cols);
            file.WriteLine(GestionMap.Instance._Rows);
            for (int i = 0; i < GestionMap.Instance._Cols; i++)
            {
                line = "";
                for (int j = 0; j < GestionMap.Instance._Rows; j++)
                {
                    if (GestionMap.Instance._Grid[i,j].GetComponent<SpriteRenderer>().color == Color.white)
                    {
                        line += "1";
                    }
                    else
                    {
                        line += "0";
                    }
                }
                file.WriteLine(line);
            }
            file.Close();
            try
            {
                pathChemin = "./Assets/save/chemin.txt";
                pathChemin = Path.GetFullPath(pathChemin);
                //string fileChemin = Path.GetFileName(pathChemin);
                using StreamWriter sw = new StreamWriter(pathChemin, append: true);
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
