using UnityEngine;
using TMPro;
public class AllTexts : MonoBehaviour
{
    public TextMeshProUGUI button_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void setText(string text)
    {
       button_text.text = text;
    }
}
