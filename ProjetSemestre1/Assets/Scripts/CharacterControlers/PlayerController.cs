using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerWalkSpeed = 50f;
    public float playerRunSpeed = 75f;
    public float playerJumpForce = 50f;
    public float mouseSensitivity = 100f;
    
    float distToGround;

    Collider playerCollider;

    Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();

        distToGround = playerCollider.bounds.extents.y;
    }

    private void Update()
    {

    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector3(0, playerRb.velocity.y, 0);

        if (Input.GetKey(KeyCode.Z))                                                                                 //player movement ZQSD AddForce over-writting previous force
        {
            playerRb.AddForce(transform.forward * playerWalkSpeed, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            playerRb.AddForce(-transform.right * playerWalkSpeed, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRb.AddForce(-transform.forward * playerWalkSpeed, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRb.AddForce(transform.right * playerWalkSpeed, ForceMode.VelocityChange);
        }
        
        if (Input.GetKey(KeyCode.Space) && IsGrounded())                                                             //jump using Addforce & isGrounded func 
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerJump");
            playerRb.AddForce(transform.up * playerJumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private bool IsGrounded()                                                                                       //isGrounded func, tests (using Rcast) if the avatar is on something
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}
