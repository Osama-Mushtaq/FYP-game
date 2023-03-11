using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedObjectPos : MonoBehaviour
{
    public static Vector3 objpos;

    public static Vector3 getObjPos()
    {
        return objpos;
    }
    public static void setObjPos(Vector3 p) { objpos = p; }
}
