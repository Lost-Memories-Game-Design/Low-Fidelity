using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class CharacterSwap : MonoBehaviour
{
    public Transform character;
    public List<Transform> possibleCharacters;
    public int whichCaracter;
    public CinemachineFreeLook cam;
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
        character.GetComponent<ThirdPersonMovement>().enabled = true;
        m_ParticleSystem.transform.position = character.position;
        m_ParticleSystem.Play();
        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<ThirdPersonMovement>().enabled = false;
            }
        }
        cam.LookAt = character;
        cam.Follow = character;
    }
}
