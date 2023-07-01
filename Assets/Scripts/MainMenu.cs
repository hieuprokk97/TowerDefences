using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Scenes/Level01";

    public SceneFader sceneFader;
   public void Play()
    {
        FindObjectOfType<SceneFader>().FadeTo(levelToLoad);
    }
    public void Quit()
    {
        Debug.Log("Exciting....");
        Application.Quit();
    }
}
