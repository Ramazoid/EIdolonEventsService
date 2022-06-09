using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public string[] datas= new string[]{"level:1 leevel:2 leve:3","award:10 award:20 award:30","spend:10 spend:20 spend:30"};
    public Text data1;
    public Text data2;
    public Text data3;
    void Start()
    {
        
    }

    public void SetEventType(Text type)
    {
        Fields.SetType(type);
        switch(type.text)
        {
            case "Level Start": SetDataButtons(0); break;
            case "Award": SetDataButtons(1); break;
            case "Spend": SetDataButtons(2); break;
        }
    }
    public void SetData(Text data)
    {
        Fields.SetData(data);
    }

    private void SetDataButtons(int n)
    {
        string[] dataButtonsText = datas[n].Split(' ');
        data1.text = dataButtonsText[0];
        data2.text = dataButtonsText[1];
        data3.text = dataButtonsText[2];
    }
}
