using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBase : InteractionBase
{
    private GameObject player;

    public GameObject flags;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.Find("InteractHitbox").GetComponent<InteractManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position)<5f)
        {
            this.transform.LookAt(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));
        }
    }

    public override void Interact()
    {
        base.Interact();
        //GameObject.Find("DialogueBox").GetComponent<DialogueScript>().DialogueInputs();
    }
}
