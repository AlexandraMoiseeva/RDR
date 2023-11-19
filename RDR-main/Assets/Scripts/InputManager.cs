using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
using Rewired.Data;

public class InputManager : MonoBehaviour
{
    [SerializeField] private int playerID = 0;
    [SerializeField] private Player controls;

    [SerializeField]
    public Input_Values inputValues;

    public FlyMode flyMode;

    [SerializeField]
    public Converted_Values convertedValues;

    Quad quad;

    void Awake()
    {
        ReInput.userDataStore.Load();
        controls = ReInput.players.GetPlayer(playerID);
    }

    private void Start()
    {
        quad = GetComponent<Quad>();
    }

    private void Update()
    {
        if (controls.GetButtonDown("UICancel"))
        {
            if (quad.uiManager != null) ChangeUI();
        }
        if (controls.GetButtonDown("UITab"))
        {
            //tab
        }
        UpdateFlyMode();
    }

    private void UpdateFlyMode()
    {
        float flymode_input = controls.GetAxis("FlyMode");
        FlyMode newMode;
        if (flymode_input > 0)
            newMode = (FlyMode) 1;
        else if(flymode_input < 0)
            newMode = (FlyMode) (-1);
        else newMode = (FlyMode) 0;

        if (flyMode != newMode) FlymodeChangedTo(newMode);

        flyMode = newMode;
    }
    private void FlymodeChangedTo(FlyMode mode)
    {
        switch (mode)
        {
            case FlyMode.Arm: quad.isArmed = true; break;
            case FlyMode.Acro: quad.isArmed = false; quad.ghost.ClearRotCash(); break;
            case FlyMode.Stab: quad.isArmed = false; break;
        }
    }
    private void FixedUpdate()
    {
        inputValues.throttle = controls.GetAxis("Throttle") + 1;
        inputValues.yaw = controls.GetAxis("Yaw");
        inputValues.pitch = controls.GetAxis("Pitch");
        inputValues.roll = controls.GetAxis("Roll");

        convertedValues.throttle = ConvertInput(inputValues.throttle);
        convertedValues.yaw = ConvertInput(inputValues.yaw);
        convertedValues.pitch = ConvertInput(inputValues.pitch);
        convertedValues.roll = ConvertInput(inputValues.roll);
    }

    private float ConvertInput(float value)
    {
        value *= Parameters.forceMultiplier;
        return value;
    }

    void ChangeUI()
    {
        quad.uiManager.ChangeUI();
    }
}
