using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Loop", menuName = "ScriptableObjects/LoopData", order = 1)]
public class LoopData : ScriptableObject
{
    public string[] flags;

    public NpcData[] npcData;

    void Start()
    {
        //Load save or default
    }
}
