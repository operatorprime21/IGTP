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
    [Tooltip("can jump variable")] public bool canRotate;
    [Tooltip("can jump variable")] public PlayerAnims anims;
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
        if(canRotate)
        {
            RotateInputs();
        }
        if(moving == "none" && turning == "none")
        {
            anims.PlayIdle();
        }
        //JumpInputs();
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
                anims.PlayWalk();
                break;
            case "backwards":
                player.transform.position -= player.transform.forward * moveSpeed;
                anims.PlayWalk();
                break;
        }
    }
    private void RotateInputs()
    {
        if (Input.GetKey(KeyCode.A))
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

        if (Input.GetKey(KeyCode.D))
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
                anims.PlayWalk();
                break;
            case "right":
                player.transform.Rotate(0f, Input.GetAxis("Horizontal") * rotateSpeed, 0f);
                anims.PlayWalk();
                break;
        }
    }
    //private void JumpInputs()
    //{
        
    //    if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.down), 1.1f, floors))
    //    {
    //        canRotate = true;
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            Jump();
    //        }
    //    }
    //    else
    //    {
    //        canRotate = false;
    //    }
    //}
    //private void Jump()
    //{
    //    playerRB.AddForce(transform.up * jumpForce);
    //}

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawSphere(transform.position, 2.5f);
    //}A
}
