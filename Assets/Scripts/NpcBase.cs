using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBase : InteractionBase
{
    private GameObject player;

    public GameObject flags;
    public GameObject npcSprite;
    public GameObject playerSprite;

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

    public override void EndDialogueEvent()
    {
        dialogueScript.OptionNo();
        npcSprite.SetActive(false);
        playerSprite.SetActive(true);
    }

    public override void Interact()
    {
        dialogueScript.DialogueInputs();
        npcSprite.SetActive(true);
        playerSprite.SetActive(false);
    }
}
