using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int Index = 0;
    public float DialogueSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }

    void ChangeTextAllignment(int i)
    {
        if (i == 0)
        {
            DialogueText.alignment = TextAlignmentOptions.Left;
        }
        else if (i == 1)
        {
            DialogueText.alignment = TextAlignmentOptions.Right;
        }
        else { DialogueText.alignment = TextAlignmentOptions.Center; }
    }

    void NextSentence()
    {
        //Debug.Log(Index);
        //Debug.Log(Sentences.Length);

        if (Index <= Sentences.Length - 1)
        {
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }
        else
        {
            DialogueText.text = "";
            //Debug.Log("I am scene 2 and I want to go to scene 3");
            SceneController.instance.loadScene(4);
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
