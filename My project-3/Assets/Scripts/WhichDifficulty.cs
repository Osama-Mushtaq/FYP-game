using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhichDifficulty : MonoBehaviour
{
    public static bool isEasy = false;
    public static bool isMed = false;
    public static bool isHard = false;

    public static void setDiff(bool b1, bool b2, bool b3)
    {
        isEasy = b1;
        isMed = b2;
        isHard = b3;
    }

}
