using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CharacterSwap : MonoBehaviour
{
    public Transform activeCharacter;
    public List<Transform> possibleCharacters;
    public int whichCaracter;
    public Camera[] characterCameras;

    public List<Light> allLights;
    public float intensity = 1;

    void Start()
    {
        if (activeCharacter == null && possibleCharacters.Count >= 1)
        {
            activeCharacter = possibleCharacters[0];
        }
        Swap();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (whichCaracter == 0)
            {
                whichCaracter = possibleCharacters.Count - 1;
            }
            else
            {
                whichCaracter -= 1;
            }
            Swap();
        }
    }

    public void ChangeLights(int characterID)
    {
        for (int i = 0; i < allLights.Count; i++)
        {
            if (characterID == 1)
            {
                allLights[i].color = new Color(25, 249, 255, 255);
                allLights[i].intensity = intensity;
            }
            else
            {
                allLights[i].color = new Color(214, 221, 22, 255);
                allLights[i].intensity = intensity;
            }
        }
    }

    public void Swap()
    {
        activeCharacter = possibleCharacters[whichCaracter];

        switch (whichCaracter)
        {
            case 0: //If activeCharacter == Child
                activeCharacter.GetComponent<Movement>().enabled = true;
                characterCameras[whichCaracter].enabled = true;

                possibleCharacters[1].GetComponent<Movement>().enabled = false;
                characterCameras[1].enabled = false;

                possibleCharacters[1].GetComponent<Follow>().enabled = true;
                possibleCharacters[1].GetComponent<NavMeshAgent>().enabled = true;
                break;
            case 1: //If activeCharacter == Ghost
                activeCharacter.GetComponent<Movement>().enabled = true;
                Debug.Log("I am: " + activeCharacter + activeCharacter.GetComponent<Movement>().enabled);
                characterCameras[whichCaracter].enabled = true;

                possibleCharacters[0].GetComponent<Movement>().enabled = false;
                characterCameras[0].enabled = false;

                possibleCharacters[1].GetComponent<Follow>().enabled = false;
                possibleCharacters[1].GetComponent<NavMeshAgent>().enabled = false;
                break;
        }

        ChangeLights(whichCaracter);
    }
}