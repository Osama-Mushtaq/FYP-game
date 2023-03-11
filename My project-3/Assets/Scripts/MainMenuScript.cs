using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Toggle t1;
    public Toggle t2;
    public Toggle t3;
    public void play()
    {
        if (t1.isOn)
        {
            Score.hitcounter = 0;
            WhichDifficulty.setDiff(true, false, false);
            SceneManager.LoadScene("Scenes/EasyScene");
        }
        else if (t2.isOn)
        {
            Score.hitcounter = 0;
            WhichDifficulty.setDiff(false, true, false);
            SceneManager.LoadScene("Scenes/MediumScene");
        }
        else if (t3.isOn)
        {
            Score.hitcounter = 0;
            WhichDifficulty.setDiff(false, false, true);
            SceneManager.LoadScene("Scenes/HardScene");
        }
    }
    public void quit()
    {
        //printing something to see if it works because won't actually quit here
        Debug.Log("Quitted");
        Application.Quit();
    }
}
