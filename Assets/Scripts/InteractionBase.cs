using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] lines;
    public InteractManager manager;
    void Start()
    {
        
    }
    private void Update()
    {
        
    }

    // Update is called once per frame
    public virtual void Interact()
    {

    }

    public virtual void EndInteract()
    {

    }
}
