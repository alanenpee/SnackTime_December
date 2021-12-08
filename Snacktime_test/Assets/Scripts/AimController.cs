using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimController : MonoBehaviour
{
    private int priorityBoost = 10;
    [SerializeField]
    private PlayerInput playerInput;
    private InputAction aimAction;
    private CinemachineVirtualCamera vCam;
    [SerializeField]
    private Canvas thirdPersonCanvas;
    [SerializeField]
    private Canvas aimCanvas;

    // Start is called before the first frame update
    void Awake()
    {
        aimAction = playerInput.actions["Aim"];
        vCam = GetComponent<CinemachineVirtualCamera>();
        aimCanvas.enabled = false;
        thirdPersonCanvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        vCam.Priority += priorityBoost;
        aimCanvas.enabled = true;
        thirdPersonCanvas.enabled = false;
    }

    private void CancelAim()
    {
        vCam.Priority -= priorityBoost;
        aimCanvas.enabled = false;
        thirdPersonCanvas.enabled = true;
    }
}
