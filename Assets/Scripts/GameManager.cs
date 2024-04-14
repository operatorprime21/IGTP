using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public CinemachineVirtualCamera cam_iso;
    public CinemachineVirtualCamera cam_pov;
    public Camera cam;
    public int camMode = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
        if(mode == 0)
        {
            cam_iso.Priority = 0;
            cam.orthographic = false;
            cam_pov.Priority = 1;
            camMode = 1;
        }
        else
        {
            cam_iso.Priority = 1;
            cam.orthographic = true;
            cam_pov.Priority = 0;
            camMode = 0;
        }
        
    }

}
