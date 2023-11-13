using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("I am scene 0 and I want to go to scene 1");
        //SceneController.instance.NextScene();
    }
}
