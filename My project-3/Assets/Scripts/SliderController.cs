using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI slidertxt;


    void Update()
    {
        slider.onValueChanged.AddListener((v) => { slidertxt.text = v.ToString("0"); });
        MaxHitScore.SetMaxHitrValue(int.Parse(slidertxt.text));
    }
}
