using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class EnableOnClickRotateAroundAxis : MonoBehaviour
{
    public GameObject cameraPlace;
    public GameObject camera;
    public GameObject cameraInstant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        cameraPlace.GetComponent<Rewired.ComponentControls.Effects.RotateAroundAxis>().enabled = true;
        camera.GetComponent<SelfRotation>().enabled = false;
    }

}
