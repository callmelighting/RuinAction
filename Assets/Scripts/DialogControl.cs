using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogControl : MonoBehaviour
{
    private Text showName;
    private Text showText;
    //private string toShowName;
    private string toShowText;
    private int textIndex;

    public int TextIndex { get => textIndex; set => textIndex = value; }

    // Start is called before the first frame update
    void Start()
    {
        showName = transform.Find("Name").GetComponent<Text>();
        showText = transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowDialog(string toShowName, string toShowText)
    {
        if (IsInvoking("ShowText"))
        {
            CancelInvoke("ShowText");
            TextIndex = 0;
            showText.text = toShowText;

        }
        else
        {
            showName.text = toShowName;
            
            showText.text = "";
            this.toShowText = toShowText;
            InvokeRepeating("ShowText", 0.0f, 0.05f);
        }
    }

    private void ShowText()
    {

        if (toShowText.Length > TextIndex)
        {
            showText.text += toShowText[TextIndex++];
        }
        else
        {
            CancelInvoke("ShowText");
            TextIndex = 0;
        }
    }
}
