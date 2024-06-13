using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcBase : InteractionBase
{
    private GameObject player;
    public GameObject playerHead;
    public GameObject head;

    public GameManager gameManager;
    public Flag flag;

    public Sprite npcSprite;
    public Sprite playerSprite;
    public Image sprite;

    public Album album;

    public enum State { talking, tasking}
    public State state;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.Find("InteractHitbox").GetComponent<InteractManager>();
        album = GameObject.Find("Album").GetComponent<Album>();
        flag = this.gameObject.GetComponent<Flag>();

    }

    // Update is called once per frame
    void Update()
    {
        HeadLook();
    }

    private void HeadLook()
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
        //

        //dialogueScript.lineIndex = 0;
        switch (state)
        {
            case State.talking:
                sprite.sprite = playerSprite;
                dialogueScript.OptionNo();
                gameManager.ProgressFlag(flag);
                break;
            case State.tasking:
                if (album.canvasGroup.alpha == 0)
                {
                    Opacity(1);
                }
                else
                {
                    Opacity(0);
                    dialogueScript.OptionNo();
                }
                break;
        }
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

    public void Opacity(int i)
    {
        album.Opacity(i);
    }
}
