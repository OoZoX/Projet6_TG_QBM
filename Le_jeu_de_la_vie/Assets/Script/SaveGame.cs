using System.IO;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SaveGame : MonoBehaviour
{

    [SerializeField] public Button button_save;
    [SerializeField] private TMP_InputField _NameFile;
    private string path;
    private string line;

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
            for (int i = 0; i < CreateMap.Instance._ColX; i++)
            {
                line = "";
                for (int j = 0; j < CreateMap.Instance._ColY; j++)
                {
                    if (CreateMap.Instance._Grid[i,j].GetComponent<SpriteRenderer>().color == Color.white)
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

        }
        finally
        {
            Debug.Log("probleme save !");
        }
        Debug.Log("button save");
    }
}
