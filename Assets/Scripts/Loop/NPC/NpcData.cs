using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "ScriptableObjects/NpcData", order = 2)]
public class NpcData : ScriptableObject
{
    public Transform transform;
    public string[] lines;
    public int flagIndex;
    public NpcBase.State npcState;
}
