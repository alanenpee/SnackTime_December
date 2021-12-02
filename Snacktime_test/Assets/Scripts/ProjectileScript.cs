using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float force = 1f;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        //Add force to shooting
        rb.AddForce(transform.right * force, ForceMode.Impulse);
   
    }
}
