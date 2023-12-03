using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    public Transform playerBody;
    public Transform playerBodyPlace;

    float radius;
    float screneWidth;
    float angle;
    float initialPosY;
    // Start is called before the first frame update
    void Start()
    {
        radius = System.Math.Abs(playerBody.localPosition.z);
        screneWidth = Screen.width;
        angle = 0;
        initialPosY = playerBodyPlace.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 1000 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 1000 * Time.deltaTime;

        angle = mouseX * 180 / screneWidth;
        playerBodyPlace.Rotate(0, angle, 0);
    }
}
