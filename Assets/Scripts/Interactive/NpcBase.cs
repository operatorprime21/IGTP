using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcBase : InteractionBase
{
    private GameObject player;
    public GameObject playerHead;
    public GameObject head;

    public List<List<string>> flags = new List<List<string>>();

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
        Vector3 dir = (playerHead.transform.position - head.transform.position).normalized;
        float angle = Vector3.Angle(dir, this.transform.forward);
        float dist = Vector3.Distance(head.transform.position, playerHead.transform.position);
        if (Mathf.Abs(angle) <= 60 && dist <= 10f)
        {
            head.transform.LookAt(playerHead.transform.position);
        }
        else head.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
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
