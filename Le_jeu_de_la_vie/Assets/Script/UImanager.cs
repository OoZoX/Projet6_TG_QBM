using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour

{
    public Slider sliderCol;
    public Slider sliderRow;
    public TextMeshProUGUI textSliderValueCols;
    public TextMeshProUGUI textSliderValueRows;
    string sliderMessage;

    private int _NewCols = 100;
    private int _NewRows = 100;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void ShowSliderValue(Slider slider)
    {
        sliderMessage = slider.value.ToString();
        Debug.Log(sliderMessage);

        if (slider.name == "ColumnRow")
        {

            textSliderValueCols.GetComponent<TextMeshProUGUI>().SetText(sliderMessage);
            ChangeCols(slider.value);
        }
        else
        {
            textSliderValueRows.GetComponent<TextMeshProUGUI>().SetText(sliderMessage);
            ChangeRows(slider.value);
        }
    }


    public void ChangeRows(float value)
    {
        _NewRows = (int)value;
    }


    public void ChangeCols(float value)
    {
        _NewCols = (int)value;
    }

    public void Generate()
    {
        GestionMap.Instance.ChangeSizeMap(_NewCols, _NewRows);
    }
}
    

