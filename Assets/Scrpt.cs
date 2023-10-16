using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class Scrpt : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;
    public bool isCanvas1Active = true;
    
    public void SwitchCanvas()
    {
        if (isCanvas1Active)
        {
            canvas1.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(true);
            isCanvas1Active = false;
        }
        else
        {
            canvas1.gameObject.SetActive(true);
            canvas2.gameObject.SetActive(false);
            isCanvas1Active = true;
        }
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
    
    private void OnActionButtonClick(Action action)
    {
        _firstNumber = ConvertF(result.text);
        result.text = "";
        _action = action;
    }

    private void Update()
    {
        if (result.text.Contains(","))
        {
            commaButton.interactable = false;
        }
        else
        {
            commaButton.interactable = true;
        }
        
        if (result.text.Contains("Infinito"))
        {
            result.text = result.text.Replace("Infinito", "Infinity");
        }
    }

    private void Start()
    {
        plusButton.onClick.AddListener(() =>
        {
            OnActionButtonClick(Action.Plus);
        });
        
        minusButton.onClick.AddListener(() =>
        {
            OnActionButtonClick(Action.Minus);
        });
        
        mulButton.onClick.AddListener(() =>
        {
            OnActionButtonClick(Action.Mul);
        });
        
        divButton.onClick.AddListener(() =>
        {
            OnActionButtonClick(Action.Div);
        })
            ;
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
        result.text = result.text.Substring(0, result.text.Length - 1);
    }
    
    public void OnNumberClick(string number)
    { 
        result.text += number;
    }
    
    private void OnCommaClick()
    {
        {
            result.text += ",";
        }
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
        if (result.text == "")
        {
            float resultPi = Mathf.PI;
            result.text = ConvertS(resultPi);
        }
        else
        {
            float value = float.Parse(result.text);
            float resultPi = value * Mathf.PI;
            result.text = ConvertS(resultPi);
        }
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