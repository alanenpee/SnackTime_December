using System.Collections;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float force;
    public Rigidbody rb;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    // Start is called before the first frame update
    void Start()
    {


        Destroy(gameObject, 5f);
        //Add force to shooting
        rb.AddForce((target - transform.position).normalized * force, ForceMode.Impulse);
        if(!hit && Vector3.Distance(transform.position, target) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Human")
        {
            Destroy(gameObject);
        }
    }

}
