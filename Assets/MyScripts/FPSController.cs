using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
     int myvaule;
    public float speed = 2f;
    public float sensitivity = 2f;
    public bool invertYAxis = true;
    
    CharacterController player;

    public GameObject camera;

    float moveForward = 0f;
    float moveStrafe = 0f;
    float moveUp = 0f;

    float rotX;
    float rotY;

    float jumpSpeed = 8f;
    float gravity = 9.8f;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.isGrounded)
        {
            moveUp = 0;
            if (Input.GetKeyDown("space"))
            {
                moveUp = jumpSpeed;
            }
        }

        moveUp -= gravity * Time.deltaTime;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        moveForward = Input.GetAxis("Vertical") * speed;
        moveStrafe = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(moveStrafe, moveUp, moveForward);

        transform.Rotate(0f, rotX, 0f);
        camera.transform.Rotate((invertYAxis ? -1 : 1) * rotY, 0f, 0f);

        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);
    }
}
