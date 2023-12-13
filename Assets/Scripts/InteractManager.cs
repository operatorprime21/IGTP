using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    public GameObject dialogueCanvas;
    private DialogueScript dialogue;
    public InteractManager manager;
    public GameObject interactWith;
    private void Start()
    {
        dialogue = dialogueCanvas.GetComponent<DialogueScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(interactWith != null)
            {
                interactWith.GetComponent<InteractionBase>().Interact();
                
            }
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
