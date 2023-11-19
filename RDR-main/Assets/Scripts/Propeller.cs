using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Propeller : MonoBehaviour
{
    public float maxPower;
    public float power;
    public float mass;
    public float length;
    public float step;
    public float weight;
    public float elasticity;
    public int countOfBlades;
    public bool isArmed;
    public BladeType bladeType;
    public BladeMaterial bladeMaterial;
    public float rotationSpeed;
    public float rotationSpeed_K;
    float gizmos_K = 1;
    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        //body.maxAngularVelocity = 0;
        //body.useGravity = false;
    }

    void FixedUpdate()
    {
        //rotationSpeed = power * rotationSpeed_K;
        transform.Rotate(new Vector3(0, 0, transform.rotation.normalized.z + rotationSpeed));
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, power));
    }

    public void SetPower(float p)
    {
        power = p;
    }

    public float GetMaxPower()
    {
       return power;
    }

    public void AddPower(float value)
    {
        power += value;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector3 from = transform.position;
        Vector3 to = from;
        to.y += (power * gizmos_K);
        Gizmos.DrawLine(from, to);
    }

    void CheckPower()
    {
        if (power > maxPower) { power = maxPower;}
        else if (power < -maxPower) { power = -maxPower; }
        rotationSpeed = power * rotationSpeed_K;
    }
}


