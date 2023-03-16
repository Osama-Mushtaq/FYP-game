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

    void OnMouseDown()
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
    //*using update
    // void Update()
    // {
    //     RaycastHit hit;
    //     if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, 100))
    //     {
    //         Renderer renderer = hit.collider.GetComponent<Renderer>();
    //         if (renderer.name == "Sphere")
    //         {
    //             Vector3 size = transform.lossyScale;
    //             Vector3 pos = transform.position;
    //             Vector3 newPosition = transform.position;
    //             // newPosition.x = Random.Range(-spawnRange.x, spawnRange.x);
    //             // newPosition.y = Random.Range(size.y, spawnRange.y);
    //             newPosition.x = pos.x;
    //             newPosition.y = pos.y;
    //             newPosition.z = Random.Range(spawnRange.z, (float)2 * spawnRange.z);
    //             transform.position = newPosition;
    //         }
    //     }
    // }

}

/**
        //!declarations for changing crosshair color
        public Canvas crshr;
        private Color32 color = new Color(0.5f, 1f, 0.5f, 1f);
        //! declarations end for changing crosshair color
        //!Code for changing crosshair color
        Transform objectTransform = crshr.transform.Find("my_crosshair");
        Graphic objectGraphic = objectTransform.GetComponentInChildren<Graphic>();
        objectGraphic.color = color;

        Image[] objectImages = objectTransform.GetComponentsInChildren<Image>();
        foreach (Image image in objectImages)
        {
            image.color = color;
        }
        //!code end dor changing crosshair color
*/