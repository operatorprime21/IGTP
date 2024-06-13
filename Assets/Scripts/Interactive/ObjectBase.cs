using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : InteractionBase
{
    public GameObject options;
    public GameObject parent;

    public string[] npcLines;
    public Flag data;

    void Start()
    {
        data = this.gameObject.GetComponent<Flag>();
        manager = GameObject.Find("InteractHitbox").GetComponent<InteractManager>();
    }
    public override void EndDialogueEvent()
    {
        
        if(options != null)
        {
            options.SetActive(true);
        }
        else
        {
            dialogueScript.OptionNo();
        }
    }

    public override void OptionYes()
    {
        parent.SetActive(false);
        manager.manager.ProgressFlag(data);
    }

    public override void OptionNo()
    {
        //options.SetActive(false);

    }
    public override void Interact()
    {
        dialogueScript.DialogueInputs();
    }

}
