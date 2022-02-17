using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour

{
    public Slider m_sliderCol;
    public Slider m_liderRow;
    public TextMeshProUGUI m_textSliderValueCols;
    public TextMeshProUGUI m_textSliderValueRows;
    private string _SliderMessage;

    private int _NewCols = 100;
    private int _NewRows = 100;

    public void ShowSliderValue(Slider slider)
    {
        _SliderMessage = slider.value.ToString();
        Debug.Log(_SliderMessage);

        if (slider.name == "ColumnRow")
        {

            m_textSliderValueCols.GetComponent<TextMeshProUGUI>().SetText(_SliderMessage);
            ChangeCols(slider.value);
        }
        else
        {
            m_textSliderValueRows.GetComponent<TextMeshProUGUI>().SetText(_SliderMessage);
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
    

