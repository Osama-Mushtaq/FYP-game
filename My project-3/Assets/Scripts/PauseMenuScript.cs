using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public Toggle t1;
    public Toggle t2;
    public Toggle t3;
    public void Continue()
    {
        if (t1.isOn)
        {
            SceneManager.LoadScene("Scenes/EasyScene");
        }
        else if (t2.isOn)
        {
            SceneManager.LoadScene("Scenes/MediumScene");
        }
        else if (t3.isOn)
        {
            SceneManager.LoadScene("Scenes/HardScene");
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}
