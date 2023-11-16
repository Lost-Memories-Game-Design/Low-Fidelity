using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static UnityEditor.Progress;

/// <summary>
/// Simple example of Grabbing system.
/// </summary>
public class PlayerInteraction : MonoBehaviour
{
    // Reference to the character camera.
    [SerializeField]
    private Camera characterCamera;
    // Reference to the slot for holding picked item.
    [SerializeField]
    private Transform? slot;
    // Reference to the currently held item.
    private PickableItem pickedItem;

    public AudioSource eventAudio;
    bool m_HasAudioPlayed;

    public GameObject Memories;

    /// <summary>
    /// Method called very frame.
    /// </summary>
    private void Update()
    {
        // Execute logic only on button pressed
        if (Input.GetButtonDown("Fire1"))
        {
            // Check if player picked some item already
            if (slot != null && pickedItem)
            {
                // If yes, drop picked item
                DropItem(pickedItem);
            }
            else
            {
                // If no, try to pick item in front of the player
                // Create ray from center of the screen
                var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
                RaycastHit hit;
                // Shot ray to find object to pick
                if (Physics.Raycast(ray, out hit, 10f))
                {
                    if (slot != null)
                    {
                        // Check if object is pickable
                        var pickable = hit.transform.GetComponent<PickableItem>();
                        // If object has PickableItem class
                        if (pickable)
                        {
                            // Pick it
                            PickItem(pickable);

                            Memories.GetComponent<MemoryCollecting>().Collection.Remove(pickedItem);
                        }
                    }

                    Interactable? _interactable = hit.transform.GetComponent<Interactable>();
                    if (_interactable != null)
                        _interactable.Trigger();

                    if (!m_HasAudioPlayed)
                    {
                        eventAudio.Play();
                        m_HasAudioPlayed = true;
                    }

                }
            }
        }
    }
    /// <summary>
    /// Method for picking up item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void PickItem(PickableItem item)
    {
        if (!m_HasAudioPlayed)
        {
            eventAudio.Play();
            m_HasAudioPlayed = true;
        }

        // Assign reference
        pickedItem = item;
        // Disable rigidbody and reset velocities
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;
        // Set Slot as a parent
        item.transform.SetParent(slot);
        // Reset position and rotation
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;

        //Memories.GetComponent<MemoryCollecting>().Collection.Remove(item);
    }
    /// <summary>
    /// Method for dropping item.
    /// </summary>
    /// <param name="item">Item.</param>
    private void DropItem(PickableItem item)
    {
        // Remove reference
        pickedItem = null;
        // Remove parent
        item.transform.SetParent(null);
        // Enable rigidbody
        item.Rb.isKinematic = false;
        // Add force to throw item a little bit
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);

        //Memories.GetComponent<MemoryCollecting>().Collection.Remove(item);
    }
}
