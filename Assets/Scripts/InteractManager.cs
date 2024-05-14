using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public GameObject dialogueCanvas;
    private DialogueScript dialogue;
    public InteractManager manager;
    public GameObject interactWith;

    public CamSwitcher camSwitch;

    private void Start()
    {
        dialogue = dialogueCanvas.GetComponent<DialogueScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(interactWith != null && camSwitch.mode == 0)
            {
                interactWith.GetComponent<InteractionBase>().Interact();
                //camSwitch.CamSwitch();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && interactWith == null)
        {
            camSwitch.CamSwitch();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactable")
        {
            interactWith = other.gameObject;
            dialogueCanvas.SetActive(true);
            dialogue.lines = other.GetComponent<InteractionBase>().lines;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            interactWith = null;
            dialogueCanvas.SetActive(false);
            dialogueCanvas.GetComponent<DialogueScript>().lines = null;
        }
    }
}
