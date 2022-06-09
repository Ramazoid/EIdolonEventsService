using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public Slider coolDownSlider;
    public Text coolDownWalue;

    public float value { get => int.Parse(coolDownWalue.text);
              set { } }

    void Start()
    {
        
    }

    public void SetValue(float n)
    {
        coolDownWalue.text = Mathf.Floor(n * 100).ToString();
    }
    void Update()
    {
        
    }
}
