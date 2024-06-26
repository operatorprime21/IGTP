using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> povOnly = new List<GameObject>();
    public List<GameObject> isoOnly = new List<GameObject>();

    public List<LoopData> loops = new List<LoopData>();
    public LoopData curLoop;
    public List<EnvironmentData> envData = new List<EnvironmentData>();

    public int flagIndex;
    public NpcBase npc;

    public void ToggleVisible(List<GameObject> on, List<GameObject> off)
    {
        foreach(GameObject obj in on)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in off)
        {
            obj.SetActive(false);
        }
    }

    void Start()
    {
        
    }
    public void ProgressFlag(Flag flag)
    {
        if(flag.flag == curLoop.flags[flagIndex] && flag.used == false)
        {
            //Debug.Log("Flag success: " + flagIndex + " " + curLoop.flags[flagIndex].ToString());
            flag.used = true;
            flagIndex++;
            //Debug.Log("New flag: " + flagIndex + " " + curLoop.flags[flagIndex].ToString());
            foreach(NpcData npcData in curLoop.npcData)
            {
                if(flagIndex == npcData.flagIndex)
                {
                    SetNPC(npcData.transform, npcData.lines, npcData.npcState);
                    break;
                }
            }
            foreach (EnvironmentData envData in envData)
            {
                if(envData.loopIndex == loops.IndexOf(curLoop))
                {
                    if (envData.flagIndex == flagIndex)
                    {
                        EditDoors(envData.doorsToClose, envData.doorsToOpen);
                        break;
                    }
                }
            }
        }
    }

    public void SetNPC(Transform transform,  string[] lines, NpcBase.State state)
    {
        npc.gameObject.transform.position = transform.position;
        npc.gameObject.transform.rotation = transform.rotation;
        npc.lines = lines;
        npc.state = state;
    }

    public void EditDoors(List<Door> doorToDisable, List<Door> doorToEnable)
    {
        foreach(Door door in doorToDisable)
        {
            door.gameObject.SetActive(false);
        }
        foreach (Door door in doorToEnable)
        {
            door.gameObject.SetActive(true);
        }
    }
}
