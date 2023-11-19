using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkTest : MonoBehaviour
{
    public GameObject ClickEffect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Click((Camera.main.ScreenToWorldPoint(Input.mousePosition)));
    }
    public void Click(Vector2 mousePosition)
    {
        Instantiate(ClickEffect, mousePosition, Quaternion.identity, transform);
    }
}
