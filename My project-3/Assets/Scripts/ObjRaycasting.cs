using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjRaycasting : MonoBehaviour
{
    //!declarations for changing crosshair color
    public Canvas crshr;
    private Color32 color = new Color(0.5f, 1f, 0.5f, 1f);
    //! declarations end for changing crosshair color
    public float waitTime = 4f;

    private bool isWaiting = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100) && Input.GetMouseButtonDown(0))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer.name == "Sphere")
            {
                StartCoroutine(WaitAndChangeColor());
            }
        }
    }
    IEnumerator WaitAndChangeColor()
    {
        // Check if already waiting
        if (isWaiting)
        {
            yield break;
        }

        // Set waiting flag
        isWaiting = true;

        // Wait for the specified time
        yield return new WaitForSeconds(waitTime);

        // Change the color of the crosshair
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

        // Reset waiting flag
        isWaiting = false;
    }
}
