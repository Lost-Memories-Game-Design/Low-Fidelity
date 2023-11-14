using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryCollecting : MonoBehaviour
{
    public List<PickableItem> Collection;
    private bool isCollected = false;

    void Update()
    {
        if (Collection.Count != 1 && !isCollected) //the number is the amount that needs to be collected
        {
            CompletedCollection();
        }
    }

    public void CompletedCollection()
    {
        isCollected = true;
        Debug.Log("I am scene 1 and I want to go to scene 2");
        SceneController.instance.NextScene();
    }
}
