using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIDManager : MonoBehaviour
{
    [SerializeField]
    public PID_Correction pidCorrection;

    public PID pitchPID;
    public PID rollPID;
    public PID yawPID;
    public float PID_K;

    [Range(0, 100)]
    public int PitchP, PitchI, PitchD, RollP, RollI, RollD, YawP, YawI, YawD;

    private void Awake()
    {
        pidCorrection = new PID_Correction();
        pitchPID = new PID(PID_Properties.pitch_P, PID_Properties.pitch_I, PID_Properties.pitch_D);
        rollPID = new PID(PID_Properties.roll_P, PID_Properties.roll_I, PID_Properties.roll_D);
        yawPID = new PID(PID_Properties.yaw_P, PID_Properties.yaw_I, PID_Properties.yaw_D);
    }
    void Start()
    {

    }

    private void Update()
    {
        //Для тестов пида в реальном времени через палзунки
        /*
        PID_Properties.pitch_P = PitchP;
        PID_Properties.pitch_I = PitchI;
        PID_Properties.pitch_D = PitchD;
        PID_Properties.roll_P = RollP;
        PID_Properties.roll_I = RollI;
        PID_Properties.roll_D = RollD;
        PID_Properties.yaw_P = YawP;
        PID_Properties.yaw_I = YawI;
        PID_Properties.yaw_D = YawD;
        */
        pitchPID.kP = PID_Properties.pitch_P * PID_K;
        pitchPID.kI = PID_Properties.pitch_I * PID_K;
        pitchPID.kD = PID_Properties.pitch_D * PID_K;

        rollPID.kP = PID_Properties.roll_P * PID_K;
        rollPID.kI = PID_Properties.roll_I * PID_K;
        rollPID.kD = PID_Properties.roll_D * PID_K;

        yawPID.kP = PID_Properties.yaw_P * PID_K;
        yawPID.kI = PID_Properties.yaw_I * PID_K;
        yawPID.kD = PID_Properties.yaw_D * PID_K;
    }
}
