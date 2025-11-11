using System.Collections.Generic;
using ParaTrooper;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    [SerializeField] private Bullets Bullet;
    [SerializeField] private GameObject BulletParent;
    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private Transform RotatingPoint;
    private float LookSensitivity;
    private Vector3 RotatingVector;
    public List<Bullets> Bullets;
    private PlayerControl inputActions;
    private void Awake()
    {
        inputActions = new PlayerControl();
        inputActions.Player.Enable();
        inputActions.Player.Left.performed += OnLeftPerformed;
        inputActions.Player.Right.performed += OnRightPerformed;
        inputActions.Player.Fire.performed += OnFirePerformed;
        LookSensitivity = 0;
        RotatingVector = Vector3.zero;
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
        LookSensitivity = Constants.AimSensitivity;
        RotatingVector = new Vector3(0, 0, LookSensitivity);
    }
    private void OnRightPerformed(InputAction.CallbackContext context)
    {
        LookSensitivity = -Constants.AimSensitivity;
        RotatingVector = new Vector3(0, 0, LookSensitivity);
    }
    void FixedUpdate()
    {
        if (LookSensitivity > 0)
        {
            if (RotatingPoint.localEulerAngles.z < 255)
            {
                RotatingPoint.localEulerAngles += RotatingVector;
            }
            return;
        }
        if (LookSensitivity < 0)
        {
            if (RotatingPoint.localEulerAngles.z > 105)
            {
                RotatingPoint.localEulerAngles += RotatingVector;
            }
            return;
        }
    }
    //**************************Bullets*******************************
    private void OnFirePerformed(InputAction.CallbackContext context)
    {
        Bullets bullet = GetBullet();
        bullet.transform.position = BulletSpawn.position;
        bullet.FireBullet(BulletSpawn.up.normalized);
        LookSensitivity = 0;
    }
    private Bullets GetBullet()
    {
        foreach (Bullets shot in Bullets)
        {
            if (!shot.gameObject.activeInHierarchy)
            {
                return shot;
            }
        }
        Bullets bullet = Instantiate(Bullet, BulletParent.transform);
        Bullets.Add(bullet);
        return bullet;
    }
}
