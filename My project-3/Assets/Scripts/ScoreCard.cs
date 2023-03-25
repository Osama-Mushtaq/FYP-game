using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCard : MonoBehaviour
{
    public TextMeshProUGUI txt;

    void Start()
    {
        txt.text = "Score=" + Score.hitcounter + "/" + MaxHitScore.GetMaxHitValue();
    }


    void OnMouseDown()
    {
        if (ObjRaycasting.canHit == true)
        {
            Score.hitcounter += 1;
            txt.text = "Score=" + Score.hitcounter + "/" + MaxHitScore.GetMaxHitValue();
            if (Score.hitcounter == MaxHitScore.GetMaxHitValue())
            {
                Score.hitcounter = 0;
            }
        }
    }

}
