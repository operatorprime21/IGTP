using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : InteractionBase
{
    public GameObject options;
    public GameObject parent;

    public override void EndDialogueEvent()
    {
        options.SetActive(true);
        //Debug.Log("called");
    }

    public override void OptionYes()
    {
        parent.SetActive(false);
    }

    public override void OptionNo()
    {
        //options.SetActive(false);

    }
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.Find("InteractHitbox").GetComponent<InteractManager>();
    }
    public override void Interact()
    {
        base.Interact();
        GameObject.Find("DialogueBox").GetComponent<DialogueScript>().DialogueInputs();
    }

}
