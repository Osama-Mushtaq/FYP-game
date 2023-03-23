using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjRaycasting : MonoBehaviour
{
    public Canvas crshr;
    private Color32 originalColor = new Color32(255, 255, 255, 255);
    private Color32 targetColor = new Color32(127, 255, 127, 255);
    public float waitTime = 4f;

    private bool isWaiting = false;
    private bool isTargetObject = false;
    private Coroutine colorCoroutine;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer.name == "Sphere")
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
                if (colorCoroutine != null)
                {
                    StopCoroutine(colorCoroutine);
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
        //TODO: can add the new code here of CLICKING
        isWaiting = false;
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
