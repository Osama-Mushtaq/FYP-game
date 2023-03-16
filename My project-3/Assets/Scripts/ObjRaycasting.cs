using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class ObjRaycasting : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         RaycastHit hit;
//         if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
//         {
//             Renderer renderer = hit.collider.GetComponent<Renderer>();
//             if (renderer.name == "Sphere")
//             {

//             }
//         }
//     }
// }

public class ObjRaycasting : MonoBehaviour
{
    // The original color of the crosshair
    public Color originalColor = Color.white;

    // The color of the crosshair when it's on the Sphere object
    public Color sphereColor = Color.green;

    // The sprite renderer of the crosshair
    public CanvasRenderer crosshairRenderer;

    // Flag to indicate if the crosshair color is changing
    private bool isColorChanging = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer.name == "Sphere" && !isColorChanging)
            {
                // Start the coroutine to change the color of the crosshair
                StartCoroutine(ChangeCrosshairColor(sphereColor));
            }
        }
        else if (!isColorChanging)
        {
            // Start the coroutine to change the color of the crosshair back to the original color
            StartCoroutine(ChangeCrosshairColor(originalColor));
        }
    }

    // Coroutine to change the color of the crosshair
    private IEnumerator ChangeCrosshairColor(Color targetColor)
    {
        isColorChanging = true;
        yield return new WaitForSeconds(4f);

        // Change the color of the crosshair
        crosshairRenderer.SetColor(targetColor);

        isColorChanging = false;
    }
}
