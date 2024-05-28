using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POVCamAnims : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anims;
    public GameObject camPov;
    public GameObject camIso;
    public GameManager manager;
    public GameObject player;

    public void PlayEntry()
    {
        anims.Play("entry");
    }

    public void PlayExit()
    {
        anims.Play("exit");
    }

    public void ExitSwitch()
    {
        manager.ToggleVisible(manager.isoOnly, manager.povOnly);
        camPov.SetActive(false);
        camIso.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
