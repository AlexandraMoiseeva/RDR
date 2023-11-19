using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassBar : MonoBehaviour
{
    public RawImage compassImage;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        compassImage.uvRect = new Rect(camera.localEulerAngles.y / 360f, 0f, 1f, 1f);
    }
}
