using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EasyDifficultyClickableObject : MonoBehaviour
{
    public Vector3 spawnRange = new Vector3(2, 4, 5);

    void Start()
    {
        if (SavedObjectPos.getcond() == true)
        {
            transform.position = SavedObjectPos.getObjPos();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 size = transform.lossyScale;
            Vector3 pos = transform.position;
            Vector3 newPosition = transform.position;
            // newPosition.x = Random.Range(-spawnRange.x, spawnRange.x);
            // newPosition.y = Random.Range(size.y, spawnRange.y);
            newPosition.x = pos.x;
            newPosition.y = pos.y;
            newPosition.z = Random.Range(spawnRange.z, (float)2 * spawnRange.z);
            transform.position = newPosition;
        }
    }
    // void OnMouseDown()
    // {

    //     Vector3 size = transform.lossyScale;
    //     Vector3 pos = transform.position;
    //     Vector3 newPosition = transform.position;
    //     // newPosition.x = Random.Range(-spawnRange.x, spawnRange.x);
    //     // newPosition.y = Random.Range(size.y, spawnRange.y);
    //     newPosition.x = pos.x;
    //     newPosition.y = pos.y;
    //     newPosition.z = Random.Range(spawnRange.z, (float)2 * spawnRange.z);
    //     transform.position = newPosition;

    // }
}
