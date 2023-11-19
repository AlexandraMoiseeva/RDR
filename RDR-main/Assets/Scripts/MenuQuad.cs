using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MenuQuad : MonoBehaviour
{
    public Quad quad;
    Rigidbody body;

    private void Start()
    {
        body = quad.GetRigidbody();
        body.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        quad.DisableCameras();
    }

    public void Respawn()
    {
        body = quad.GetRigidbody();
        quad.Respawn();
        body.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        quad.DisableCameras();
    }
}
    
