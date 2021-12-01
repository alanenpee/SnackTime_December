using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float force = 1f;
    public Rigidbody rb;
    private Vector3 rotationTorque = new Vector3(20f,20f,20f);

    // Start is called before the first frame update
    void Start()
    {
        //Add force + multiplier to shooting
        rb.AddForce(transform.right * force, ForceMode.Impulse);
        //Add rotation torque and power
        rb.AddTorque(rotationTorque * 100f);
    }
}
