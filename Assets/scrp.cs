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
    public Button percentButton;
    
    private float _firstNumber;
    private float _secondNumber;
    private string _ection = "";

    private void Start()
    {
        plusButton.onClick.AddListener(OnSumClick);
        clearButton.onClick.AddListener(OnClearClick);
        resButton.onClick.AddListener(OnResultClick);
        minusButton.onClick.AddListener(OnMinusClick);
        mulButton.onClick.AddListener(OnMulClick);
        divButton.onClick.AddListener(OnDivClick);
        backButton.onClick.AddListener(OnBackClick);
        percentButton.onClick.AddListener(OnPercentClick);
    }

    private void OnSumClick()
    {
        _firstNumber = float.Parse(result.text, CultureInfo.InvariantCulture.NumberFormat);
        result.text = "";
        _ection = "+";
    }

    private void OnMinusClick()
    {
        _firstNumber = float.Parse(result.text, CultureInfo.InvariantCulture.NumberFormat);
        result.text = "";
        _ection = "-";
    }
    
    private void OnMulClick()
    {
        _firstNumber = float.Parse(result.text, CultureInfo.InvariantCulture.NumberFormat);
        result.text = "";
        _ection = "*";
    }
    
    private void OnDivClick()
    {
        _firstNumber = float.Parse(result.text, CultureInfo.InvariantCulture.NumberFormat);
        result.text = "";
        _ection = "/";
    }

    private void OnClearClick()
    {
        result.text = "";
        _firstNumber = 0f;
        _secondNumber = 0f;
        _ection = "";
    }
    
    private void OnPercentClick()
    {
        _firstNumber = float.Parse(result.text, CultureInfo.InvariantCulture.NumberFormat);
        result.text = "";
    }

    private void OnResultClick()
    { 
        _secondNumber = float.Parse(result.text, CultureInfo.InvariantCulture.NumberFormat);
        switch (_ection)
        {
            case "+":
                result.text = (_firstNumber + _secondNumber).ToString(CultureInfo.InvariantCulture);
                break;
            
            case "-":
                result.text = (_firstNumber - _secondNumber).ToString(CultureInfo.InvariantCulture);
                break;
            
            case "*":
                result.text = (_firstNumber * _secondNumber).ToString(CultureInfo.InvariantCulture);
                break;
            
            case "/":
                result.text = (_firstNumber / _secondNumber).ToString(CultureInfo.InvariantCulture);
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
}