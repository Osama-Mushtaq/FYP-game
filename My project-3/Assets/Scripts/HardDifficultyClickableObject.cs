using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDifficultyClickableObject : MonoBehaviour
{
    public Vector3 spawnRange = new Vector3(2, 6, 10);

    void Start()
    {
        if (SavedObjectPos.getcond() == true)
        {
            transform.position = SavedObjectPos.getObjPos();
        }
    }
    void OnMouseDown()
    {
        Vector3 size = transform.lossyScale;
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(-spawnRange.x, spawnRange.x);
        newPosition.y = Random.Range(size.y, spawnRange.y);
        newPosition.z = Random.Range(spawnRange.z, (float)1.5 * spawnRange.z);
        transform.position = newPosition;
    }
}
