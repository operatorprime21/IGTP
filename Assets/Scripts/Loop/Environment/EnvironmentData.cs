using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "EnvironmentData", menuName = "ScriptableObjects/EnvironmentData", order = 3)]
public class EnvironmentData : MonoBehaviour
{
    public List<Door> doorsToClose;
    public List<Door> doorsToOpen;
    public int loopIndex;
    public int flagIndex;
}

