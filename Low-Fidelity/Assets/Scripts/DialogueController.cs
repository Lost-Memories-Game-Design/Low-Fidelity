using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;
    public GameObject message;

    public AudioSource eventAudio;
    bool m_HasAudioPlayed;

    public TextMeshProUGUI NamePlate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }

    void ChangeTextAllignment(int i)
    {
        if (i % 2 == 0)
        {
            DialogueText.alignment = TextAlignmentOptions.Left;
        }
        else if(i % 2 != 0)
        {
            DialogueText.alignment = TextAlignmentOptions.Right;
        }
        else { DialogueText.alignment = TextAlignmentOptions.Center; }
    }

    void NextSentence()
    {
        if (Index <= Sentences.Length - 1)
        {
            DialogueText.text = "";

            if (Index == 3 && NamePlate != null)
            {
                NamePlate.text = "Amelia";
            }

            StartCoroutine(WriteSentence());
        }
        else
        {
            DialogueText.text = "";

            if (message != null)
            {
                if (!m_HasAudioPlayed)
                {
                    eventAudio.Play();
                    m_HasAudioPlayed = true;
                }

                message.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneController.instance.NextScene();
                }
            }
            else
            {
                SceneController.instance.NextScene();
            }
        }
    }

    IEnumerator WriteSentence()
    {
        foreach (char Character in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Character;

            ChangeTextAllignment(Index);

            yield return new WaitForSeconds(DialogueSpeed);
        }
        Index++;
    }
}
