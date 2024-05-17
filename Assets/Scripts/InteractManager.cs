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
            other.GetComponent<InteractionBase>().dialogueScript = dialogue;
            dialogue.lines = other.GetComponent<InteractionBase>().lines;
            dialogue.interact = other.GetComponent<InteractionBase>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            interactWith = null;
            dialogueCanvas.SetActive(false);
            other.GetComponent<InteractionBase>().dialogueScript = null;
            dialogue.lines = null;
            dialogue.interact = null;
        }
    }
}
