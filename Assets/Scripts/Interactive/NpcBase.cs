using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcBase : InteractionBase
{
    private GameObject player;

    public GameObject flags;
    public Sprite npcSprite;
    public Sprite playerSprite;
    public Image sprite;
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
        //npcSprite.SetActive(false);
        //playerSprite.SetActive(true);
        sprite.sprite = playerSprite;
        dialogueScript.OptionNo();
    }

    public override void Interact()
    {
        sprite.sprite = npcSprite;
        dialogueScript.DialogueInputs();
        //npcSprite.SetActive(true);
        //playerSprite.SetActive(false);
    }

    public override void OptionNo()
    {
        
    }
}
