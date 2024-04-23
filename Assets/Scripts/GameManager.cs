using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public GameObject cam_pov;

    public int camMode = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(camMode == 0)
            {
                SwitchCamMode(1);
            }
            else
            {
                SwitchCamMode(0);
            }
        }
    }

    void SwitchCamMode(int mode)
    {
        if(mode == 1)
        {
            cam_pov.SetActive(true);
            camMode = 1;
        }
        else
        {
            cam_pov.SetActive(false);
            camMode = 0;
        }
        
    }

}
