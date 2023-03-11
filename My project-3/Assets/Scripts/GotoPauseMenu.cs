using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoPauseMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SavedObjectPos.setObjPos(transform.position);
            SavedObjectPos.setcond(true);
            SceneManager.LoadScene("Scenes/PauseMenu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
