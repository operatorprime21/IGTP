using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Control variables")]
    [Tooltip("Camera object")] public GameObject player;
    [Tooltip("how fast the camera drops")] public float moveSpeed;
    [Tooltip("how fast the camera rotates")] public float horRotate;
    [Space(10)]

    [Header("Movement debug variables")]
    [Tooltip("allows the camera to turn with the last pressed key")] [SerializeField] private string turning = "none";
    [Tooltip("allows the camera to turn with the last held key")] [SerializeField] private string overloadTurn = "none";
    [Tooltip("allows the camera to move with the last pressed key")] [SerializeField] private string moving = "none";
    [Tooltip("mask checking if player is colliding with anything")] [SerializeField] private LayerMask walls;
    [Tooltip("mask checking if player is on stairs")] [SerializeField] private LayerMask stairs;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        WalkingInputs();
        InputHandlerRotation();
        Turn();
    }

    private void WalkingInputs()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moving = InputHandlerWalking("forwards", Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moving = InputHandlerWalking("backwards", Vector3.back);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            moving = "none";
        }

        Walk();
    }
    private string InputHandlerWalking(string dir, Vector3 face)
    {
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(face), 1f, walls))
        {
            return "none";
        }
        else
        {
            return dir;
        }
    }
    public void Walk()
    {
        switch (moving)
        {
            case "forwards":
                player.transform.position += player.transform.forward * moveSpeed;
                break;
            case "backwards":
                player.transform.position -= player.transform.forward * moveSpeed;
                break;
        }
    }
    private void InputHandlerRotation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            turning = "left";
            if (overloadTurn == "none")
            {
                overloadTurn = "left";
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (overloadTurn == "none")
            {
                turning = "none";
            }
            else if (overloadTurn == "left")
            {
                if (turning == "left")
                {
                    turning = "none";
                    overloadTurn = "none";
                }
                else
                {
                    overloadTurn = "right";
                }
            }
            else
            {
                turning = overloadTurn;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            turning = "right";
            if (overloadTurn == "none")
            {
                overloadTurn = "right";
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (overloadTurn == "none")
            {
                turning = "none";
            }
            else if (overloadTurn == "right")
            {
                if (turning == "right")
                {
                    turning = "none";
                    overloadTurn = "none";
                }
                else
                {
                    overloadTurn = "left";
                }
            }
            else
            {
                turning = overloadTurn;
            }
        }
    }
    public void Turn()
    {
        switch (turning)
        {
            case "left":
                player.transform.Rotate(0f, -Input.GetAxis("Horizontal") * -horRotate, 0f);
                break;
            case "right":
                player.transform.Rotate(0f, Input.GetAxis("Horizontal") * horRotate, 0f);
                break;
            case "none":
                break;
        }
    }
}
