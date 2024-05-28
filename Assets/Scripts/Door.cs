using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractionBase
{
    public GameObject roomFrom;
    public GameObject roomTo;
    public float transitionSpeed;
    public GameObject pointFrom;
    public GameObject pointTo;

    public GameObject player;

    public override void Interact()
    {
        base.Interact();
        roomTo.SetActive(true);
        player.GetComponent<PlayerMovement>().playerRB.useGravity = false;
        player.transform.position = pointFrom.transform.position;     
        roomFrom.SetActive(false);

        player.transform.position = pointTo.transform.position;
        player.GetComponent<PlayerMovement>().playerRB.useGravity = true;

        manager = GameObject.Find("InteractHitbox").GetComponent<InteractManager>();
        manager.interactWith = null;
    }
}
