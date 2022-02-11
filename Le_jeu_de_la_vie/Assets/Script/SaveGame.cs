using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveGame : MonoBehaviour
{

    [SerializeField]public Button button_save;

    private void Start()
    {

        button_save = GetComponent<Button>();


        button_save.onClick.AddListener(TaskOnClickSave);

    }


    private void TaskOnClickSave()
    {
        Debug.Log("button save");
    }
}
