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

    private Transform cameraTransform;

    public static PlayerMovement instance;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        //GROUND CHECK
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //APPLY GRAVITY
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //PLAYER INPUT
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        //PLAYER MOVEMENT
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);
        moveDirection = moveDirection.x * cameraTransform.right.normalized + moveDirection.z * cameraTransform.forward.normalized;
        moveDirection.y = 0f;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        moveDirection.Normalize();


        //ROTATE PLAYER IN MOVEMENT DIRECTION
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.Euler(0,cameraTransform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
