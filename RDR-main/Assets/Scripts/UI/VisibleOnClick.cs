using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleOnClick : MonoBehaviour
{
    public GameObject SettingPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Visible()
    {
        if (SettingPanel.activeSelf)
            SettingPanel.SetActive(false);
        else
            SettingPanel.SetActive(true);

    }
}
