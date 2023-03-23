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
                // Set flag to indicate the target object is in focus
                isTargetObject = true;
                // If not waiting, start coroutine to change color after wait time
                if (!isWaiting)
                {
                    colorCoroutine = StartCoroutine(WaitAndChangeColor());
                }
            }
            else
            {
                // Reset flags and stop the color change coroutine if the target object is not in focus
                isTargetObject = false;
                isWaiting = false;
                if (colorCoroutine != null)
                {
                    StopCoroutine(colorCoroutine);
                }
                ResetColor();
            }
        }
        else
        {
            // Reset flags and stop the color change coroutine if the target object is not in focus
            isTargetObject = false;
            isWaiting = false;
            if (colorCoroutine != null)
            {
                StopCoroutine(colorCoroutine);
            }
            ResetColor();
        }
    }

    IEnumerator WaitAndChangeColor()
    {
        // Set waiting flag
        isWaiting = true;

        // Wait for the specified time
        yield return new WaitForSeconds(waitTime);

        // Check if still targeting the object before changing color
        if (isTargetObject)
        {
            // Change the color of the crosshair
            Transform objectTransform = crshr.transform.Find("my_crosshair");
            Graphic objectGraphic = objectTransform.GetComponentInChildren<Graphic>();
            objectGraphic.color = targetColor;

            Image[] objectImages = objectTransform.GetComponentsInChildren<Image>();
            foreach (Image image in objectImages)
            {
                image.color = targetColor;
            }
        }

        // Reset waiting flag
        isWaiting = false;
    }

    void ResetColor()
    {
        // Reset the color of the crosshair to the original color
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
