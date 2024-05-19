using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] lines;
    public InteractManager manager;
    public DialogueScript dialogueScript;
    void Start()
    {
        
    }
    private void Update()
    {
        
    }

    // Update is called once per frame
    public void Interact()
    {
        dialogueScript.DialogueInputs();
    }

    public virtual void EndInteract()
    {

    }


    public virtual void EndDialogueEvent()
    {

    }

    public virtual void OptionYes()
    {

    }

    public virtual void OptionNo()
    {

    }
}
