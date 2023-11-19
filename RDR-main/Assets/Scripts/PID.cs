using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PID
{
    private float P;
    private float I;
    private float D;

    public float kP;
    public float kI;
    public float kD;

    float error_old = 0f;
    //The controller will be more robust if you are using a further back sample
    float error_old_2 = 0f;
    float error_sum = 0f;
    //If we want to average an error as input
    //float error_sum2 = 0f;

    //Sometimes you have to limit the total sum of all errors used in the I
    private readonly float error_sumMax = 20f;
    //private bool isOn;
    public float prevErr;

    public PID(float P, float I, float D)
    {
        kP = P;
        kI = I;
        kD = D;
    }

    public void Drop()
    {
        prevErr = 0;
    }

    public float Calculate(float currErr)
    {
        P = currErr;
        I += P * Time.fixedDeltaTime;
        D = (P - prevErr) / Time.fixedDeltaTime;
        prevErr = currErr;

        return P * kP + I * kI + D * kD;
    }

    public float Calculate2(float error)
    {
        //The output from PID
        float output = 0f;
        //P
        output += kP * error;

        //I
        error_sum += Time.fixedDeltaTime * error;
        //Clamp the sum 
        this.error_sum = Mathf.Clamp(error_sum, -error_sumMax, error_sumMax);

        //Sometimes better to just sum the last errors
        //float averageAmount = 20f;
        //CTE_sum = CTE_sum + ((CTE - CTE_sum) / averageAmount);
        output += kI * error_sum;

        //D
        float d_dt_error = (error - error_old) / Time.fixedDeltaTime;
        //Save the last errors
        this.error_old_2 = error_old;
        this.error_old = error;
        output += kD * d_dt_error;

        return output;
    }
}