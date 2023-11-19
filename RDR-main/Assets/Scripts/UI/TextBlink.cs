using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBlink : MonoBehaviour
{
    [Range(0, 10)]
    public float period;

    private Color currColor;

    void Start()
    {
        currColor = GetComponent<Text>().color;
    }

    void Update()
    {
        float a = Mathf.PingPong(Time.time, period) / period;
        GetComponent<Text>().color = new Color(currColor.r, currColor.g, currColor.b, a);
    }
}
