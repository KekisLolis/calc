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
        _firstNumber = ConvertF(result.text);
        result.text = "";
        _action = "+";
    }

    private void OnMinusClick()
    {
        _firstNumber = ConvertF(result.text);
        result.text = "";
        _action = "-";
    }
    
    private void OnMulClick()
    {
        _firstNumber = ConvertF(result.text);
        result.text = "";
        _action = "*";
    }
    
    private void OnDivClick()
    {
        _firstNumber = ConvertF(result.text);
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
        _secondNumber = ConvertF(result.text);
        switch (_action)
        {
            case "+":
                result.text = ConvertS(_firstNumber + _secondNumber);
                break;
            
            case "-":
                result.text = ConvertS(_firstNumber - _secondNumber);
                break;
            
            case "*":
                result.text = ConvertS(_firstNumber * _secondNumber);
                break;
            
            case "/":
                result.text = ConvertS(_firstNumber / _secondNumber);
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
        
        result.text = ConvertS(factorial);
    }
    
    public void Percent()
    {
        float value = float.Parse(result.text);
        float percent = value / 100f;
        
        result.text = ConvertS(percent);
    }
    
    public void Degree()
    {
        float value = float.Parse(result.text);
        float resultPow = Mathf.Pow(value, 2f);
        
        result.text = ConvertS(resultPow);
    }
    
    public void Sqrt()
    {
        float value = float.Parse(result.text);
        float resultSqrt = Mathf.Sqrt(value);
        
        result.text = ConvertS(resultSqrt);
    }
    
    public void Pi()
    {
        float value = float.Parse(result.text);
        float resultPi = value * Mathf.PI;
        
        result.text = ConvertS(resultPi);
    }

    public void Exponent()
    {
        if (result.text == "")
        {
            float resultExp = Mathf.Exp(1f);
            result.text = ConvertS(resultExp);
        }
        else
        {
            float value = float.Parse(result.text);
            float resultExp = value * Mathf.Exp(1f);
            result.text = ConvertS(resultExp);
        }
    }

    private static string ConvertS(float value)
    {
        return value.ToString(CultureInfo.GetCultureInfo("es-ES"));
    }
    
    private static float ConvertF(string value)
    {
        return float.Parse(value, CultureInfo.GetCultureInfo("es-ES"));
    }
        
}