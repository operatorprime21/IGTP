using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public GameObject iso;
    public GameObject pov;

    public int mode;
    public GameManager manager;
    void Start()
    {
        mode = 0;
        manager.ToggleVisible(manager.isoOnly, manager.povOnly);
        iso.SetActive(true);
        pov.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CamSwitch()
    {
        if(iso.activeInHierarchy)
        {
            mode = 1;
            manager.ToggleVisible(manager.povOnly, manager.isoOnly);
            iso.SetActive(false);
            pov.SetActive(true);
        }
        else
        {
            mode = 0;
            manager.ToggleVisible(manager.isoOnly, manager.povOnly);
            iso.SetActive(true);
            pov.SetActive(false);
        }
    }
}