using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHitScore : MonoBehaviour
{
    public static int maxhitValue;

    public static void SetMaxHitrValue(int value)
    {
        maxhitValue = value;
    }

    public static float GetMaxHitValue()
    {
        return maxhitValue;
    }
}
