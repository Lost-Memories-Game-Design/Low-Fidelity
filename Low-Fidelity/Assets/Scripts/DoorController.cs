using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, Interactable
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    string AnimationName;

    public void Trigger()
    {
        animator.Play(AnimationName);
    }
}
