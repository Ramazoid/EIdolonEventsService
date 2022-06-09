using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct Events
{
    public string type;
    public string data;
    public Events(string type, string data)
    {
        this.type = type;
        this.data = data;

    }
}
public class Fields : MonoBehaviour
{
    public InputField typeField;
    public InputField dataField;
    static private Fields IN;
    private EventService ES;
    

    void Start()
    {
        IN = this;
        ES = GetComponent<EventService>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal static void SetType(Text type)
    {
        IN.typeField.text = type.text;
    }

    internal static void SetData(Text data)
    {
        IN.dataField.text = data.text;
    }
    public void Send()
    {
        ES.TrackEvent(IN.typeField.text, IN.dataField.text);

    }
}