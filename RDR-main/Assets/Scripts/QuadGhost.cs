using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadGhost : MonoBehaviour
{
    public Quad quadBody;
    InputManager inputManager;
    public float maxAngle;
    public float yawSpeed;
    public float rollSpeed;
    public float pitchSpeed;
    float yRot = 0;
    float xRot = 0;
    float zRot = 0;

    private void Start()
    {
        inputManager = quadBody.GetComponent<InputManager>();
    }

    public void SetUp(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    void AngleGhostStable()
    {
        float xRot = inputManager.inputValues.pitch * maxAngle;
        float zRot = inputManager.inputValues.roll * maxAngle;
        yRot += inputManager.inputValues.yaw * yawSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(xRot, yRot, -zRot);
    }

    void AngleGhostAcro()
    {
        yRot += inputManager.inputValues.yaw * yawSpeed * Time.deltaTime;
        zRot += inputManager.inputValues.roll * rollSpeed * Time.deltaTime;
        xRot += inputManager.inputValues.pitch * pitchSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(xRot, yRot, -zRot);
    }

    public Quaternion GetRotation()
    {
        return transform.rotation;
    }

    private void FixedUpdate()
    {

        transform.position = quadBody.transform.position;
        switch (inputManager.flyMode)
        {
            case FlyMode.Stab: AngleGhostStable(); break;
            case FlyMode.Acro: AngleGhostAcro(); break;
            case FlyMode.Arm: break;
            default: break;
        }
    }

    public void ClearRotCash()
    {
        yRot = 0; xRot = 0; zRot = 0;
    }

    private void OnDrawGizmos()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, collider.size);
    }
}
