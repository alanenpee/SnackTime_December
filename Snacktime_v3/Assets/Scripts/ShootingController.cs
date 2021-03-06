using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    public Transform playerArm;
    public Transform shootingPoint;

    public float mouseSensitivity = 100f;
    public float sensitivityMultiplier;
    float xRotation = 0f;

    public GameObject[] Projectiles;
    public GameObject currentProjectile;
    public int selectedProjectile = 0;


    // Start is called before the first frame update
    void Start()
    {
    Cursor.lockState = CursorLockMode.Locked;
    currentProjectile = Projectiles[0];

    }

    // Update is called once per frame
    public void Update()
    {

        //Mouse input for player arm,
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * sensitivityMultiplier;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 0f);
        playerArm.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        playerArm.Rotate(Vector3.up * mouseY);

        if (Input.GetButtonDown("Fire1"))
        { 
         Instantiate(currentProjectile, shootingPoint.transform.position, shootingPoint.transform.rotation);
        }

        ChangeProjectile();

    }

    // Change your projectile with mouse scroll
    public void ChangeProjectile()
    {
        for (int i = 0; i < Projectiles.Length; i++);

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
          selectedProjectile++;
          if(selectedProjectile >= Projectiles.Length)
           {
                selectedProjectile = 0;
           }
        }
        
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            selectedProjectile--;
            if(selectedProjectile < 0)
            {
                selectedProjectile = Projectiles.Length -1;
            }
        }

        currentProjectile = Projectiles[selectedProjectile];

    }

}
