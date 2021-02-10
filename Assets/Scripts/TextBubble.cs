using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBubble : MonoBehaviour
{
    public GameObject textBoxUI;
    public Text textDisplay;
    public InputField inputField;
    private string inputString;
    public void OnKeyBoardLogoPressed()
    {
        textBoxUI.SetActive(true);
    }
    public void OnCancelButtonClicked()
    {
        textBoxUI.SetActive(false);
    }
    public void OnOkButtonClicked()
    {
        inputString = inputField.text;
        textBoxUI.SetActive(false);
        Debug.Log(inputString);
    }
}
