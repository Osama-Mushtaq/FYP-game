using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjRaycasting : MonoBehaviour
{
    public Canvas crshr;
    private Color32 originalColor = new Color32(255, 255, 255, 255);
    private Color32 targetColor = new Color32(127, 255, 127, 255);
    private float waitTime = 2f;
    private Vector3 spawnRange = new Vector3(2, 4, 5);

    private bool isWaiting = false;
    private bool isTargetObject = false;
    public static bool canHit = false;
    private Coroutine colorCoroutine;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {

            if (hit.collider.gameObject.name == "Sphere")
            {
                isTargetObject = true;
                if (!isWaiting)
                {
                    colorCoroutine = StartCoroutine(WaitAndChangeColor());
                }
            }
            else
            {
                isTargetObject = false;
                isWaiting = false;
                canHit = false;
                if (colorCoroutine != null)
                {
                    StopCoroutine(WaitAndChangeColor());
                }
                ResetColor();
            }
        }
    }
    IEnumerator WaitAndChangeColor()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        if (isTargetObject)
        {
            Transform objectTransform = crshr.transform.Find("my_crosshair");
            Graphic objectGraphic = objectTransform.GetComponentInChildren<Graphic>();
            objectGraphic.color = targetColor;
            Image[] objectImages = objectTransform.GetComponentsInChildren<Image>();
            foreach (Image image in objectImages)
            {
                image.color = targetColor;
            }
        }
        isWaiting = false;
        canHit = true;
    }
    void ResetColor()
    {
        Transform objectTransform = crshr.transform.Find("my_crosshair");
        Graphic objectGraphic = objectTransform.GetComponentInChildren<Graphic>();
        objectGraphic.color = originalColor;
        Image[] objectImages = objectTransform.GetComponentsInChildren<Image>();
        foreach (Image image in objectImages)
        {
            image.color = originalColor;
        }
    }
}
