using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    [SerializeField] public Button button_load;
    void Start()
    {
        button_load = GetComponent<Button>();
        button_load.onClick.AddListener(TaskOnClickLoad);
    }

    private void TaskOnClickLoad()
    {
        Debug.Log("button load");

    }
}
