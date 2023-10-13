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
    public ParticleSystem m_ParticleSystem;

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
    public void Swap()
    {
        character = possibleCharacters[whichCaracter];
        character.GetComponent<Movement>().enabled = true;
        m_ParticleSystem.transform.position = character.position;
        m_ParticleSystem.Play();
        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<Movement>().enabled = false;
                characterCameras[i].enabled = false;
            }
        }
        characterCameras[whichCaracter].enabled = true;
    }
}
