using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> povOnly = new List<GameObject>();
    public List<GameObject> isoOnly = new List<GameObject>();

    public List<Flag> flags = new List<Flag>();

    public enum Phase { start, objective}

    public Phase phase;

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
}
