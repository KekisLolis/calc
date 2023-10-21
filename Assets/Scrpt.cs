using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class Scrpt : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    
    public void SwitchCanvas()
    {
        canvas1.SetActive(!canvas1.activeSelf);
        canvas2.SetActive(!canvas2.activeSelf);
    }
    
    public TMP_InputField result;
    public Button plusButton;
    public Button minusButton;
    public Button mulButton;
    public Button divButton;
    public Button clearButton;
    public Button resButton;
    public Button backButton;
    public Button commaButton;
    
    private float _firstNumber;
    private float _secondNumber;
    private Action _action;

    private enum Action
    {
        Plus, Minus, Mul, Div, None
    }

    private void Update()
    {
        commaButton.interactable = !result.text.Contains(",");

        if (result.text.Contains("Infinito"))
        {
            result.text = result.text.Replace("Infinito", "Infinity");
        }
    }

    private void OnActionButtonClick(Action action)
    {
        _firstNumber = ConvertF(result.text);
        result.text = "";
        _action = action;
    }
    
    private void Start()
    {
        plusButton.onClick.AddListener(() =>
        {
            OnActionButtonClick(Action.Plus);
        });
        
        minusButton.onClick.AddListener(() =>
        {
            if (result.text == "")
            {
                result.text = "-";
            }
            OnActionButtonClick(Action.Minus);
        });
        
        mulButton.onClick.AddListener(() =>
        {
            OnActionButtonClick(Action.Mul);
        });
        
        divButton.onClick.AddListener(() =>
        {
            OnActionButtonClick(Action.Div);
        });
        
        backButton.onClick.AddListener(OnBackClick);
        clearButton.onClick.AddListener(OnClearClick);
        resButton.onClick.AddListener(OnResultClick);
        commaButton.onClick.AddListener(OnCommaClick);
    }

    private void OnClearClick()
    {
        result.text = "";
        _firstNumber = 0f;
        _secondNumber = 0f;
        _action = Action.None;
    }

    private void OnResultClick()
    { 
        _secondNumber = ConvertF(result.text);
        switch (_action)
        {
            case Action.Plus:
                result.text = ConvertS(_firstNumber + _secondNumber);
                break;
            case Action.Minus:
                result.text = ConvertS(_firstNumber - _secondNumber);
                break;
            case Action.Mul:
                result.text = ConvertS(_firstNumber * _secondNumber);
                break;
            case Action.Div:
                result.text = ConvertS(_firstNumber / _secondNumber);
                break;
        }
    }
    
    private void OnBackClick()
    {
        if (result.text.Contains("Infinity"))
        {
            OnClearClick();
        }
        if (result.text.Contains("NaN"))
        {
            OnClearClick();
        }
        
        result.text = result.text.Substring(0, result.text.Length - 1);
    }
    
    public void OnNumberClick(string number)
    {
        if (result.text.Contains("Infinity"))
        {
            OnClearClick();
        }
        if (result.text.Contains("NaN"))
        {
            OnClearClick();
        }
        
        result.text += number;
    }
    
    private void OnCommaClick()
    {
        if (result.text.Contains("Infinity"))
        {
            OnClearClick();
        }
        if (result.text.Contains("NaN"))
        {
            OnClearClick();
        }
        
        if (result.text == "")
        {
            result.text += "0,";
        }
        else
        {
            result.text += ",";
        }
    }
    
    public void Percent()
    {
        float value = float.Parse(result.text);
        float percent = value / 100f;
        result.text = ConvertS(percent);
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