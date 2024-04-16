using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public GameObject iso;
    public GameObject pov;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CamSwitch()
    {
        if(iso.activeInHierarchy)
        {
            iso.SetActive(false);
            pov.SetActive(true);
        }
        else
        {
            iso.SetActive(true);
            pov.SetActive(false);
        }
    }
}
