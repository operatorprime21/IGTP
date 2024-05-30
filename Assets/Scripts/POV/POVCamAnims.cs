using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POVCamAnims : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anims;
    public CamSwitcher switcher;
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
        switcher.ExitEvent();
    }
}
