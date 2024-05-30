using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    public Animator anims;
    void Start()
    {
        PlayIdle();
    }

    public void PlayIdle()
    {
        anims.Play("idle");
    }
    public void PlayWalk()
    {
        anims.Play("walk");
    }

}
