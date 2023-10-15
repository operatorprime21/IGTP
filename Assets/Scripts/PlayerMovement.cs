using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Control variables")]
    [Tooltip("Player object")] public GameObject player;
    [Tooltip("how fast the player moves")] public float moveSpeed;
    [Tooltip("how fast the player rotates")] public float rotateSpeed;
    [Tooltip("jump force")] public float jumpForce;
    [Space(10)]

    [Header("Movement debug variables")]
    [Tooltip("allows the player to turn with the last pressed key")] [SerializeField] private string turning = "none";
    [Tooltip("allows the player to turn with the last held key")] [SerializeField] private string overloadTurn = "none";
    [Tooltip("allows the player to move with the last pressed key")] [SerializeField] public string moving = "none";
    [Tooltip("player rigidbody")] [SerializeField] public Rigidbody playerRB;
    [Space(10)]

    [Header("Layer mask handling")]
    [Tooltip("mask distance")] [SerializeField] private float dist;
    [Tooltip("mask checking if player is colliding with anything")] [SerializeField] private LayerMask walls;
    [Tooltip("mask checking if player is on ladders")] [SerializeField] private LayerMask ladder;
    [Tooltip("mask checking if player is on the floor")] [SerializeField] private LayerMask floors;


    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        WalkInputs();
        RotateInputs();
        JumpInputs();
    }

    private void WalkInputs()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moving = WalkLogic("forwards", Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moving = WalkLogic("backwards", Vector3.back);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            moving = "none";
        }

        Walk();
    }
    private string WalkLogic(string dir, Vector3 face)
    {
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(face), dist, walls))
        {
            return "none";
        }
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(face), dist, ladder))
        {
            playerRB.useGravity = false;
            return "up";
        }
        else
        {
            playerRB.useGravity = true;
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
            case "up":
                player.transform.position += player.transform.up * moveSpeed;
                break;
        }
    }
    private void RotateInputs()
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
        Turn();
    }
    public void Turn()
    {
        switch (turning)
        {
            case "left":
                player.transform.Rotate(0f, -Input.GetAxis("Horizontal") * -rotateSpeed, 0f);
                break;
            case "right":
                player.transform.Rotate(0f, Input.GetAxis("Horizontal") * rotateSpeed, 0f);
                break;
            case "none":
                break;
        }
    }
    private void JumpInputs()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.down), 1.1f, floors))
            {
                Jump();
            }
        }
    }
    private void Jump()
    {
        playerRB.AddForce(transform.up * jumpForce);
    }
}