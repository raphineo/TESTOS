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
    float xRotation = 0f;

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
        /*float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;                                 //mouse movement
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);                                                                 //rotation clamp

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);                                               //player rotation
        gameObject.transform.Rotate(Vector3.up * mouseX);*/
    }

    void FixedUpdate()
    {
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
