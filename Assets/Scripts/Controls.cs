using System.Collections.Generic;
using ParaTrooper;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Transform rotatingPoint;
    private float lookDirection;
    private Vector3 rotatingVector;
    private PlayerControl inputActions;
    ObjectsManager objectsManager;
    Score score;
    private void Awake()
    {
        inputActions = new PlayerControl();
        inputActions.Player.Enable();
        inputActions.Player.Left.performed += OnLeftPerformed;
        inputActions.Player.Right.performed += OnRightPerformed;
        inputActions.Player.Fire.performed += OnFirePerformed;
        lookDirection = 0;
        rotatingVector = Vector3.zero;
    }
    void Start()
    {
        objectsManager = ObjectsManager.GetManager();
        score = Score.GetScoreManager();
    }
    void OnDisable()
    {
        inputActions.Player.Left.performed -= OnLeftPerformed;
        inputActions.Player.Right.performed -= OnRightPerformed;
        inputActions.Player.Fire.performed -= OnFirePerformed;
    }
    //**************************Movement*******************************
    private void OnLeftPerformed(InputAction.CallbackContext context)
    {
        lookDirection = Constants.AimSensitivity;
        rotatingVector = new Vector3(0, 0, lookDirection);
    }
    private void OnRightPerformed(InputAction.CallbackContext context)
    {
        lookDirection = -Constants.AimSensitivity;
        rotatingVector = new Vector3(0, 0, lookDirection);
    }
    void FixedUpdate()
    {
        if (lookDirection > 0)
        {
            if (rotatingPoint.localEulerAngles.z < 255)
            {
                rotatingPoint.localEulerAngles += rotatingVector;
            }
            return;
        }
        if (lookDirection < 0)
        {
            if (rotatingPoint.localEulerAngles.z > 105)
            {
                rotatingPoint.localEulerAngles += rotatingVector;
            }
            return;
        }
    }
    //**************************Bullets*******************************
    private void OnFirePerformed(InputAction.CallbackContext context)
    {
        score.AddToScore(-1);
        Bullets bullet = objectsManager.GetBullet();
        bullet.transform.position = bulletSpawn.position;
        bullet.FireBullet(bulletSpawn.up.normalized);
        lookDirection = 0;
    }
}
