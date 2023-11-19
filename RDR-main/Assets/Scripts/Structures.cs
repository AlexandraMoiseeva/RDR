using UnityEngine;

[System.Serializable]
public struct Input_Values
{
    [SerializeField]
    [Range(-1, 1)]
    public float throttle, pitch, roll, yaw;
}

[System.Serializable]
public struct Converted_Values
{
    [SerializeField]
    [Range(0, 100)]
    public float throttle;

    [SerializeField]
    [Range(-180, 180)]
    public float roll, yaw, pitch;
}

[System.Serializable]
public struct PID_Correction {[Range(-100, 100)] public float pitch, roll, yaw; }


[System.Serializable]
public struct Propellers { public Propeller propellerBR, propellerBL, propellerFR, propellerFL; }

[System.Serializable]
public struct Cameras { public Camera firstPersonCamera, thirdPersonCamera; }

public enum FlyMode{Stab = 1, Acro = 0, Arm = -1,}

public enum BladeType { Normal, Bullnose, Hybrid }

public enum BladeMaterial { Plastic, Carbon, Composit }

public enum ControlMap { FrSky_Taranis, FrSky_Taranis_X7, Radiomaster_TX12, Xbox, FSI6S_Emulator, Keyboard }

public enum Scenes { WelcomeScene, MainMenuScene , LobbyScene, RaceScene, TestMap, DestroyedCity, ControlMapperScene }