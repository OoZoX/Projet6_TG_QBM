using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LoadGame : MonoBehaviour
{
    [SerializeField] public Button button_load;
    [SerializeField] private TMP_InputField _NameFileLoad;

    void Start()
    {
        button_load = GetComponent<Button>();
        button_load.onClick.AddListener(TaskOnClickLoad);
    }

    private void TaskOnClickLoad()
    {
        Debug.Log("button load");

    }

    private void loadGame()
    {

    }
}
