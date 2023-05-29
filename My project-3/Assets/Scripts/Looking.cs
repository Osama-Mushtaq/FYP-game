using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    public float sens;
    public Transform playerBody;
    float rotateboutX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float my_X = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float my_Y = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        // float my_X = -ESP.yy * sens * Time.deltaTime;
        // float my_Y = (-10 + ESP.xx) * sens * Time.deltaTime;


        rotateboutX -= my_Y;
        rotateboutX = Mathf.Clamp(rotateboutX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotateboutX, 0f, 0f);

        playerBody.Rotate(Vector3.up * my_X);
    }
}
