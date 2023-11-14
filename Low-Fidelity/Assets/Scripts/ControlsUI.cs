using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsUI : MonoBehaviour
{
    public void Back()
    {
        SceneController.instance.loadScene(0);
    }
}
