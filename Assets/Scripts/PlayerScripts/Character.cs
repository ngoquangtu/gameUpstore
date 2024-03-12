using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public abstract class Character : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public CinemachineVirtualCamera virtualCamera;
    protected float speed;
    protected static float rotationSpeed=360.0f;
    private float targetRotation;
    Quaternion newRotation;
    public static Character Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected void Start()
    {
        variableJoystick = FindObjectOfType<VariableJoystick>();
        if (variableJoystick == null)
        {
            Debug.LogError("No VariableJoystick found in the scene!");
        }
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (virtualCamera == null)
        {
            Debug.LogError("No CinemachineVirtualCamera found in the scene!");
            return;
        }

        virtualCamera.Follow = transform;
        virtualCamera.LookAt = transform;
    }


    protected Character(float speed)
    {
        this.speed = speed;
    }

    protected void FixedUpdate()
    {
        Movement();
    }

    public abstract void bulletClick();
    public virtual void Movement()
    {
        if (variableJoystick == null)
            return;

        Vector3 direction = new Vector3(variableJoystick.Horizontal, variableJoystick.Vertical, 0f).normalized;
        transform.Translate(direction * speed * Time.fixedDeltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            targetRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90;
            newRotation = Quaternion.Euler(0f, 0f, targetRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
