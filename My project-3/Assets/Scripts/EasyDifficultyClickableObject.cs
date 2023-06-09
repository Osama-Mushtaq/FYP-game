using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EasyDifficultyClickableObject : MonoBehaviour
{
    [SerializeField] private ObjRayCasting _objRayCasting;
    private Vector3 spawnRange = new Vector3(2, 4, 5);
    public Canvas crshr;
    //private Color32 originalColor = new Color32(255, 255, 255, 255);
    void Start()
    {
        if (SavedObjectPos.getcond() == true)
        {
            transform.position = SavedObjectPos.getObjPos();
        }
    }

    void OnMouseDown()
    {
        if (_objRayCasting.CanHit == true)
        {
            Score.cccc = true;
            _objRayCasting.Reset();
            Vector3 size = transform.lossyScale;
            Vector3 pos = transform.position;
            Vector3 newPosition = transform.position;
            newPosition.x = pos.x;
            newPosition.y = pos.y;
            newPosition.z = Random.Range(spawnRange.z, (float)2 * spawnRange.z);
            transform.position = newPosition;
            //ResetColor_2();
        }
    }
}
