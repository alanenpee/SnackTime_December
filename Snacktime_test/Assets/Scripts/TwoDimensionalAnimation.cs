using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimation : MonoBehaviour
{
    float velocityZ = 0f;
    float velocityX = 0f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");   
        bool backPressed = Input.GetKey("s");   
        bool rightPressed = Input.GetKey("d");   
        bool leftPressed = Input.GetKey("a");   

        if(forwardPressed)
        {
            velocityZ = 1f;
        }
        if(backPressed)
        {
            velocityZ = -1f;
        }
        if(rightPressed)
        {
            velocityX = 1f;
        }
        if(leftPressed)
        {
            velocityX = -1f;
        }
        if(!forwardPressed && !backPressed && velocityZ != 0)
        {
            velocityZ = 0f;
        }
        if (!rightPressed && !leftPressed && velocityX != 0)
        {
            velocityX = 0f;
        }




        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    }


}
