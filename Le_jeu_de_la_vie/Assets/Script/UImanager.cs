using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour

{
public Slider sliderUI;
private TextMeshProUGUI textSliderValue;
    string sliderMessage;
    // Start is called before the first frame update
    void Start()
    {
        textSliderValue = GetComponent<TextMeshProUGUI>();
        ShowSliderValue();
    }
    public void ShowSliderValue()
    {
        sliderMessage = sliderUI.value.ToString();
        textSliderValue.SetText(sliderMessage);
    }


    public void ChangeRows(float value)
    {
        CreateMap.Instance.ChangeSizeMap(CreateMap.Instance._Cols, (int)value);
    }

    public void ChangeColumns()
    {
        CreateMap.Instance.ChangeSizeMap((int)sliderUI.value, CreateMap.Instance._Rows);
    }
}
