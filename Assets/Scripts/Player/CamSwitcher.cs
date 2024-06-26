using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public GameObject iso;
    public GameObject pov;

    public int mode;
    public GameManager manager;
    public GameObject player;
    public GameObject playerModel;
    public InteractManager interactManager;

    public POVCamAnims povAnims;
    public POVCamScripts povScripts;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CamSwitch();
        }
    }

    public void CamSwitch()
    {
        if(iso.activeInHierarchy)
        {
            mode = 1;
            manager.ToggleVisible(manager.povOnly, manager.isoOnly);
            iso.SetActive(false);
            playerModel.SetActive(false);
            pov.SetActive(true);
            povAnims.PlayEntry();
            povScripts.Defaults();
            player.GetComponent<PlayerMovement>().enabled = false;
            interactManager.enabled = false;
        }
        else
        {
            povAnims.PlayExit();
            mode = 0;
        }
    }

    public void ExitEvent()
    {
        manager.ToggleVisible(manager.isoOnly, manager.povOnly);
        interactManager.enabled = true;
        pov.SetActive(false);
        iso.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
        playerModel.SetActive(true);
    }
}
