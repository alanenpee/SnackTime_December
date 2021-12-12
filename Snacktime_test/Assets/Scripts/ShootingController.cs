using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{

    public Transform playerArm;
    public Transform shootingPoint;
    public Transform target;

    public Sprite selectedSnack;
    public Sprite[] snacks;
    public GameObject Image;

    public float perShotDelay = 0.2f;
    private float timeStamp;

    public float mouseSensitivity = 100f;
    public float sensitivityMultiplier;
    float xRotation = 0f;

    public GameObject[] Projectiles;
    public GameObject currentProjectile;
    public int selectedProjectile = 0;

    public Text projectileText;

    private Transform cameraTransform;

    Ray ray;
    RaycastHit hitInfo;

    public Animator animator;


    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentProjectile = Projectiles[0];
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
     void Update()
    {
        ChangeProjectile();
        //Mouse input for player arm,
        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90f, 0f);
        //playerArm.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        //playerArm.Rotate(Vector3.up * mouseY * Time.deltaTime);

        if (Input.GetButtonDown("Fire1") && Time.time > timeStamp)
        {
            RaycastHit hit;
            GameObject projectile = GameObject.Instantiate(currentProjectile, shootingPoint.transform.position, shootingPoint.rotation);
            ProjectileScript projectileController = projectile.GetComponent<ProjectileScript>();
            timeStamp = Time.time + perShotDelay + 0.5f;
            animator.SetTrigger("Shoot");

            
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity))
            {
                projectileController.target = hit.point;
                projectileController.hit = true;
            }
            else
            {
                projectileController.target = cameraTransform.position + cameraTransform.forward * 100f;
                projectileController.hit = true;
            }
        }
    
    }


    // CHANGE YOUR PROJECTILE  WITH MOUSE SCROLL
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

        // SHOW YOUR CURRENTLY SELECTED PROJECTILE INSIDE GUN IMAGE
        if(selectedProjectile == 0)
        {
            selectedSnack = snacks[0];
        }
        else if(selectedProjectile == 1)
        {
            selectedSnack = snacks[1];
        } 
        else if (selectedProjectile == 2)
        {
            selectedSnack = snacks[2];
        }
        currentProjectile = Projectiles[selectedProjectile];
        Image.GetComponent<Image>().sprite = selectedSnack;
    }


}
