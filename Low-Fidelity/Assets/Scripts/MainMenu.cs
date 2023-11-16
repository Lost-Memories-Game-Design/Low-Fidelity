using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneController.instance.loadScene(2);
    }

    public void ControlsExplanation()
    {
        SceneController.instance.loadScene(1);
    }
}
