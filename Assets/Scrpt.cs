using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class Scrpt : MonoBehaviour
{
    public TMP_InputField result;
    public Button plusButton;
    public Button minusButton;
    public Button mulButton;
    public Button divButton;
    public Button clearButton;
    public Button resButton;
    public Button backButton;
    
    private float _firstNumber;
    private float _secondNumber;
    private string _action = "";
    
    private void Start()
    {
        plusButton.onClick.AddListener(OnSumClick);
        clearButton.onClick.AddListener(OnClearClick);
        resButton.onClick.AddListener(OnResultClick);
        minusButton.onClick.AddListener(OnMinusClick);
        mulButton.onClick.AddListener(OnMulClick);
        divButton.onClick.AddListener(OnDivClick);
        backButton.onClick.AddListener(OnBackClick);
    }

    private void OnSumClick()
    {
        _firstNumber = float.Parse(result.text, CultureInfo.GetCultureInfo("en-EN"));
        result.text = "";
        _action = "+";
    }

    private void OnMinusClick()
    {
        _firstNumber = float.Parse(result.text, CultureInfo.GetCultureInfo("en-EN"));
        result.text = "";
        _action = "-";
    }
    
    private void OnMulClick()
    {
        _firstNumber = float.Parse(result.text, CultureInfo.GetCultureInfo("en-EN"));
        result.text = "";
        _action = "*";
    }
    
    private void OnDivClick()
    {
        _firstNumber = float.Parse(result.text, CultureInfo.GetCultureInfo("en-EN"));
        result.text = "";
        _action = "/";
    }

    private void OnClearClick()
    {
        result.text = "";
        _firstNumber = 0f;
        _secondNumber = 0f;
        _action = "";
    }

    private void OnResultClick()
    { 
        _secondNumber = float.Parse(result.text, CultureInfo.GetCultureInfo("en-EN"));
        switch (_action)
        {
            case "+":
                result.text = (_firstNumber + _secondNumber).ToString(CultureInfo.GetCultureInfo("en-EN"));
                break;
            
            case "-":
                result.text = (_firstNumber - _secondNumber).ToString(CultureInfo.GetCultureInfo("en-EN"));
                break;
            
            case "*":
                result.text = (_firstNumber * _secondNumber).ToString(CultureInfo.GetCultureInfo("en-EN"));
                break;
            
            case "/":
                result.text = (_firstNumber / _secondNumber).ToString(CultureInfo.GetCultureInfo("en-EN"));
                break;
        }
    }
    
    private void OnBackClick()
    {
        result.text = result.text.Substring(0, result.text.Length - 1);
    }
    
    public void OnNumberClick(string number)
    { 
        result.text += number;
    }
    
    public void CalculateFactorial()
    {
        float inputValue = float.Parse(result.text);

        float factorial = 1;
        for (float i = 1; i <= inputValue; i++)
        {
            factorial *= i;
        }
        
        result.text = (factorial).ToString(CultureInfo.GetCultureInfo("en-EN"));
    }
    
    public void Percent()
    {
        float value = float.Parse(result.text);
        float percent = value / 100f;
        
        result.text = (percent).ToString(CultureInfo.GetCultureInfo("en-EN"));
    }
    
    public void Degree()
    {
        float value = float.Parse(result.text);
        float resultPow = Mathf.Pow(value, 2f);
        
        result.text = (resultPow).ToString(CultureInfo.GetCultureInfo("en-EN"));
    }
    
    public void Sqrt()
    {
        float value = float.Parse(result.text);
        float resultSqrt = Mathf.Sqrt(value);
        
        result.text = (resultSqrt).ToString(CultureInfo.GetCultureInfo("en-EN"));
    }
    
    public void Pi()
    {
        float value = float.Parse(result.text);
        float resultPi = value * Mathf.PI;
        
        result.text = (resultPi).ToString(CultureInfo.GetCultureInfo("en-EN"));
    }
    
    public void Exponent()
    {
        if (result.text == "")
        {
            float resultExp = Mathf.Exp(1f);
            result.text = (resultExp).ToString(CultureInfo.GetCultureInfo("en-EN"));
        }
        else
        {
            float value = float.Parse(result.text);
            float resultExp = value * Mathf.Exp(1f);
            result.text = (resultExp).ToString(CultureInfo.GetCultureInfo("en-EN"));
        }
    }
}