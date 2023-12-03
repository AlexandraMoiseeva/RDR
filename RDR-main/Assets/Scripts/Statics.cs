using UnityEngine;


public static class DataManager
{
	static public string displayName = null;

	static public void SaveAll()
	{
		PID_Properties.Save();
		Baterry.Save();
		Parameters.Save();
		CameraProperties.Save();
		QuadCharacteristics.Save();
		ColorDrone.Save();
	}

	static public void LoadAll()
	{
		PID_Properties.Load();
		Baterry.Load();
		Parameters.Load();
		CameraProperties.Load();
		QuadCharacteristics.Load();
		ColorDrone.Load();
	}

	static public void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}
}

public static class PID_Properties
{
	static public float pitch_P;
	static public float pitch_I;
	static public float pitch_D;

	static public float yaw_P;
	static public float yaw_I;
	static public float yaw_D;

	static public float roll_P;
	static public float roll_I;
	static public float roll_D;

	public static void Save()
	{
		PlayerPrefs.SetFloat("pitch_P", pitch_P);
		PlayerPrefs.SetFloat("pitch_I", pitch_I);
		PlayerPrefs.SetFloat("pitch_D", pitch_D);

		PlayerPrefs.SetFloat("yaw_P", yaw_P);
		PlayerPrefs.SetFloat("yaw_I", yaw_I);
		PlayerPrefs.SetFloat("yaw_D", yaw_D);

		PlayerPrefs.SetFloat("roll_P", roll_P);
		PlayerPrefs.SetFloat("roll_I", roll_I);
		PlayerPrefs.SetFloat("roll_D", roll_D);

		PlayerPrefs.Save();
	}
	public static void Load()
	{
		pitch_P = PlayerPrefs.GetFloat("pitch_P", 60);
		pitch_I = PlayerPrefs.GetFloat("pitch_I", 40);
		pitch_D = PlayerPrefs.GetFloat("pitch_D", 60);

		yaw_P = PlayerPrefs.GetFloat("yaw_P", 60);
		yaw_I = PlayerPrefs.GetFloat("yaw_I", 40);
		yaw_D = PlayerPrefs.GetFloat("yaw_D", 60);

		roll_P = PlayerPrefs.GetFloat("roll_P", 60);
		roll_I = PlayerPrefs.GetFloat("roll_I", 40);
		roll_D = PlayerPrefs.GetFloat("roll_D", 60);
	}
	public static void Drop()
	{
		PlayerPrefs.DeleteKey("pitch_P");
		PlayerPrefs.DeleteKey("pitch_I");
		PlayerPrefs.DeleteKey("pitch_D");

		PlayerPrefs.DeleteKey("yaw_P");
		PlayerPrefs.DeleteKey("yaw_I");
		PlayerPrefs.DeleteKey("yaw_D");

		PlayerPrefs.DeleteKey("roll_P");
		PlayerPrefs.DeleteKey("roll_I");
		PlayerPrefs.DeleteKey("roll_D");
	}
}

public static class CameraProperties
{
	static public float angle;
	static public float FOV;
	static public float mass;
	static public bool isFirstPersonCamOn = true;

	public static void Save()
	{
		PlayerPrefs.SetFloat("angle", angle);
		PlayerPrefs.SetFloat("FOV", FOV);
		PlayerPrefs.SetFloat("mass", mass);
		PlayerPrefs.SetString("isFirstPersonCamOn", isFirstPersonCamOn.ToString());

		PlayerPrefs.Save();
	}
	public static void Load()
	{
        angle = PlayerPrefs.GetFloat("angle", 0);
		FOV = PlayerPrefs.GetFloat("FOV", 100);
		mass = PlayerPrefs.GetFloat("mass", 0.25f);
		isFirstPersonCamOn = bool.Parse(PlayerPrefs.GetString("isFirstPersonCamOn", "true"));
	}
}

public static class Baterry
{
	static public float mass;
	static public float capacity;
	static public float charge;

	public static void Save()
	{
		PlayerPrefs.SetFloat("battaryCapacity", capacity);
		PlayerPrefs.SetFloat("batteryMass", mass);

		PlayerPrefs.Save();
	}

	public static void Load()
	{
        capacity = PlayerPrefs.GetFloat("maxCharge", 30);
		mass = PlayerPrefs.GetFloat("batteryMass", 0.25f);
	}
}

public static class QuadCharacteristics
{
	static public float mass;

	public static void Save()
	{
		PlayerPrefs.SetFloat("droneMass", mass);
		PlayerPrefs.Save();
	}
	public static void Load()
	{
		mass = PlayerPrefs.GetFloat("droneMass", 6f);
	}
}

public static class Parameters
{
    static public float forceMultiplier;
    static public float massMultiplier;
    static public float musicVolume;
	static public float effectVolume;
	static public ControlMap controlMap;

	public static void Save()
	{
        PlayerPrefs.SetFloat("forceMultiplier", forceMultiplier);
        PlayerPrefs.SetFloat("massMultiplier", massMultiplier);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
		PlayerPrefs.SetFloat("effectVolume", effectVolume);
		PlayerPrefs.SetString("controlMap", controlMap.ToString());
		PlayerPrefs.Save();
    }

    public static void Load()
	{
        forceMultiplier = PlayerPrefs.GetFloat("forceMultiplier", 10);
        massMultiplier = PlayerPrefs.GetFloat("massMultiplier", 20);
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 0);
		effectVolume = PlayerPrefs.GetFloat("effectVolume", 0);
		string controlMapStr = PlayerPrefs.GetString("controlMap", "Keyboard");
		foreach (ControlMap cm in System.Enum.GetValues(typeof(ControlMap)))
		{
			if (cm.ToString() == controlMapStr) controlMap = cm;
		}
    }
}

public static class ColorDrone
{
	static public Color mesh1Color;

	public static void Save()
    {
		PlayerPrefs.SetString("mesh1Color", mesh1Color.ToString());
	}

	public static void Load()
    {
		mesh1Color = GetColor(PlayerPrefs.GetString("mesh1Color", "RGBA(0.787, 0.765, 0.000, 1.000)"));

	}

	static Color GetColor(string color)
	{
		int a = color.IndexOf('(') + 1;
		int b = color.Length - 1 - a;

		string[] values = color.Substring(a, b).Split(',');

		var culture = System.Globalization.CultureInfo.GetCultureInfo("en-US");

		return new Color(
			float.Parse(values[0], culture),
			float.Parse(values[1], culture),
			float.Parse(values[2], culture),
			float.Parse(values[3], culture));
	}
}
