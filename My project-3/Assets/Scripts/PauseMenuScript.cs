using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    // public Toggle t1;
    // public Toggle t2;
    // public Toggle t3;
    public void Continue()
    {
        if (WhichDifficulty.isEasy == true)
        {
            SceneManager.LoadScene("Scenes/EasyScene");
        }
        else if (WhichDifficulty.isMed == true)
        {
            SceneManager.LoadScene("Scenes/MediumScene");
        }
        else if (WhichDifficulty.isHard == true)
        {
            SceneManager.LoadScene("Scenes/HardScene");
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}
