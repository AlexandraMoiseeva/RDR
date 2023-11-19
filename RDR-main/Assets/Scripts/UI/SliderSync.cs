using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class SliderSync : MonoBehaviour
{
    private float value;
    public bool isInt;
    InputField text;
    Slider slider;

    private void Awake()
    {
        text = transform.Find("Input").GetComponent<InputField>();
        slider = transform.Find("Slider").GetComponent<Slider>();
        slider.value = value;
        text.text = value.ToString();
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
    private float IntCheck(float val)
    {
        if (isInt)
            val = Mathf.Round(val);
        else
            val = Mathf.Round(val * 10) / 10f;

        return val;
    }
    private float LimitsCheck(float val)
    {
        if (val > slider.maxValue)
            val = slider.maxValue;
        else if (val < slider.minValue)
            val = slider.minValue;

        return val;
    }

    private float InputCheck()
    {
        if (text.text.Contains(".")) { text.text.Replace('.', ','); }
        float val = float.Parse(text.text);
        val = IntCheck(val);
        val = LimitsCheck(val);
        return val;
    }

    private float SlideCheck()
    {
        float val = slider.value;
        val = IntCheck(val);
        //val = LimitsCheck(val);
        return val;
    }

    public float GetValue()
    {
        return value;
    }

    public void SetValue(float val)
    {
        text.text = val.ToString();
        OnTextValueChanged();
    }

    public void OnSliderValueChanged() 
    {
        float val = SlideCheck();
        slider.value = val;
        text.text = val.ToString();
        value = val;
    }

    public void OnTextValueChanged() 
    {
        float val = InputCheck();
        slider.value = val;
        text.text = val.ToString();
        value = val;
    }
}
