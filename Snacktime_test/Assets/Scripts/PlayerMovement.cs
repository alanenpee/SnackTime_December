using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed;

    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool isGrounded;

    public float rotationSpeed;

    public Animator animator;

    public static PlayerMovement instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       
        //GROUND CHECK
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //if (isGrounded && velocity.y < 0)
        //{
        //    velocity.y = -2f;
        //}

        //APPLY GRAVITY
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //PLAYER INPUT
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        //PLAYER MOVEMENT
        //Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        moveDirection.Normalize();


        //ROTATE PLAYER IN MOVEMENT DIRECTION
        if (moveDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
