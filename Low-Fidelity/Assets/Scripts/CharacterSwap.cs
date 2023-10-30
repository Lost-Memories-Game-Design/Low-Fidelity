using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    public Transform character;
    public List<Transform> possibleCharacters;
    public int whichCaracter;
    public Camera[] characterCameras;

    public List<Light> allLights;
    public float intensity = 1;

    void Start()
    {
        if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
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
        character = possibleCharacters[whichCaracter];
        character.GetComponent<Movement>().enabled = true;

        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<Movement>().enabled = false;
                characterCameras[i].enabled = false;
            }
        }
        characterCameras[whichCaracter].enabled = true;

        ChangeLights(whichCaracter);
    }
}
