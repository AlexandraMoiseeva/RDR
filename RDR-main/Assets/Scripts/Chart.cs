using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chart : MonoBehaviour
{

    Vector3[] points;
    Vector3[] points0;

    LineRenderer lineRender;

    public float score;
    

    // Start is called before the first frame update
    void Start()
    {
        points = new Vector3[300];
        score = 0.035f;
        lineRender = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; ++i)
        {
            float x0 = (i) / 1500f;
            float x = System.Math.Abs(x0);
            points[i] = new Vector3(x0, System.Math.Sign(x0) * (
                PID_Properties.pitch_P * (float)System.Math.Exp(x) +
                PID_Properties.pitch_I * (float)(System.Math.Exp(x) + System.Math.Exp(x + 1)) / 2 +
                PID_Properties.pitch_D * (float)(System.Math.Exp(x + 1) - System.Math.Exp(x)) )
                , 0);
        }

        points0 = points;

        for (int i = 0; i < points.Length; ++i)
        {
            float x = this.transform.position.x - 1;
            float y = (points0[i].y) * score / 10 + this.transform.position.y;
            float z = -(points0[i].x) * score * 1000 + this.transform.position.z;
            points[i] = new Vector3(x, y, z);
        
        }

        lineRender.positionCount = points.Length;
        lineRender.SetPositions(points);
    }

    /*private void ApplyNewData()
    {
        PID_Properties.pitch_P = pitch_P_slider.GetValue();
        PID_Properties.pitch_I = pitch_I_slider.GetValue();
        PID_Properties.pitch_D = pitch_D_slider.GetValue();

        PID_Properties.yaw_P = yaw_P_slider.GetValue();
        PID_Properties.yaw_I = yaw_I_slider.GetValue();
        PID_Properties.yaw_D = yaw_D_slider.GetValue();

        PID_Properties.roll_P = roll_P_slider.GetValue();
        PID_Properties.roll_I = roll_I_slider.GetValue();
        PID_Properties.roll_D = roll_D_slider.GetValue();
    }*/

}