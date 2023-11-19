using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadBody : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
    }
}
