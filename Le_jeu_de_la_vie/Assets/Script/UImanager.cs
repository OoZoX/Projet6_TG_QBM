using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour

{
public Slider sliderUI;
private TextMeshProUGUI textSliderValue;
    // Start is called before the first frame update
    void Start()
    {
        textSliderValue = GetComponent<TextMeshProUGUI>();
        ShowSliderValue();
    }
    public void ShowSliderValue()
    {
        string sliderMessage = sliderUI.value.ToString();
        textSliderValue.SetText(sliderMessage);
    }

    public void ChangeRows()
    {
        CreateMap.Instance._ColX = (int)sliderUI.value;
    }

    public void ChangeColumns()
    {
        CreateMap.Instance._ColY = (int)sliderUI.value;
    }
}
