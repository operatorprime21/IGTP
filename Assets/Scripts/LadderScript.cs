using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public GameObject ladderDest;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if(player.moving == "up")
            {
                other.transform.position = ladderDest.transform.position;
                player.playerRB.useGravity = true;
            }
        }
    }
}
