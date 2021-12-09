using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestMovement : MonoBehaviour
{
    private Vector3 PlayerInput;
    public Rigidbody myrb;
    public float speed;
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

     void FixedUpdate()
    {
        PlayerInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 MoveDirection = transform.TransformDirection(PlayerInput) * speed;
        myrb.velocity = new Vector3(MoveDirection.x, myrb.velocity.y, MoveDirection.z);


    }
}
