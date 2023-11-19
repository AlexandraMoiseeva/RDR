using UnityEngine;
using System.Collections;

public class DebugLogConsole : MonoBehaviour
{
    private bool consoleishidden;
    private string output;
    private string stack;
    public GUISkin consoleskin;
    private Vector2 scroll;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown("`") || Input.GetKeyDown("~"))
        {
            ShowHideConsole();
        }
    }
    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void OnGUI()
    {
        if (consoleishidden)
        {
            ShowConsole();
        }
    }

    void ShowHideConsole()
    {
        if (consoleishidden)
        {
            Debug.Log("\nConsole Shown");
            consoleishidden = false;
        }
        else
        {
            consoleishidden = true;
        }
    }
    void ShowConsole()
    {
        GUILayout.BeginArea(new Rect(0, 5, Screen.width, Screen.height / 2));
        scroll = GUILayout.BeginScrollView(scroll);
        GUILayout.Label(output);
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        output += type + ": " + logString + "\n";
        stack += stackTrace;
        scroll.y = float.MaxValue;
    }
}
