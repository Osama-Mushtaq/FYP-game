using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCard : MonoBehaviour
{
    public TextMeshProUGUI txt;
    [SerializeField] private ObjRayCasting _objRayCasting;

    void Start()
    {
        txt.text = "Score=" + Score.hitcounter + "/" + MaxHitScore.GetMaxHitValue();
    }


    void OnMouseDown()
    {
        if (Score.cccc == true)
        {
            Score.hitcounter += 1;
            txt.text = "Score=" + Score.hitcounter + "/" + MaxHitScore.GetMaxHitValue();
            if (Score.hitcounter == MaxHitScore.GetMaxHitValue())
            {
                Score.hitcounter = 0;
            }
            Score.cccc = false;
        }
    }

    public void Demofunc()
    {
        if (Score.cccc == true && Score.demo == true)
        {
            Score.hitcounter += 1;
            txt.text = "Score=" + Score.hitcounter + "/" + MaxHitScore.GetMaxHitValue();
            if (Score.hitcounter == MaxHitScore.GetMaxHitValue())
            {
                Score.hitcounter = 0;
            }
            Score.cccc = false;
            Score.demo = false;
        }
    }

}
