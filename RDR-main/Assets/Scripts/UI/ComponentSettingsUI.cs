using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ComponentSettingsUI : MonoBehaviour
{
    public List<GameObject> componentPanels;

    public SliderSync batteryMass_slider, batteryCapacity_slider;
    public SliderSync quadMass_slider;
    public SliderSync camMass_slider, camFOV_slider, camAngle_slider;

    GameObject body;

    void Start()
    {
        SetDataToUI();
        ShowPanel(null);

        body = GameObject.Find("Mesh1");
    }

    private void SetDataToUI()
    {
        print(CameraProperties.mass);
        camMass_slider.SetValue(CameraProperties.mass);
        camFOV_slider.SetValue(CameraProperties.FOV);
        camAngle_slider.SetValue(CameraProperties.angle);

        quadMass_slider.SetValue(QuadCharacteristics.mass);

        batteryMass_slider.SetValue(Baterry.mass);
        batteryCapacity_slider.SetValue(Baterry.capacity);
    }

    private void SaveCameraProperties()
    {
        print(camMass_slider.GetValue());
        CameraProperties.mass = camMass_slider.GetValue();
        CameraProperties.FOV = camFOV_slider.GetValue();
        CameraProperties.angle = camAngle_slider.GetValue();
    }

    private void SaveBattery()
    {
        Baterry.mass = batteryMass_slider.GetValue();
        Baterry.capacity = batteryCapacity_slider.GetValue();
    }

    private void SaveQuadProperties()
    {
        QuadCharacteristics.mass = quadMass_slider.GetValue();
    }

    public void Apply()
    {
        SaveCameraProperties();
        SaveBattery();
        SaveQuadProperties();
        ColorDrone.mesh1Color = body.GetComponent<MeshRenderer>().materials[1].color;
        DataManager.SaveAll();
    }

    public void ShowPanel(string panelName)
    {
        foreach (GameObject panel in componentPanels)
        {
            if (panel.name == panelName)
            {
                panel.GetComponent<MenuPanelComponent>().Show();
                transform.Find("ButtonPanel").Find(panel.name + "Button").Find("Image").gameObject.SetActive(true);
            }
            else
            {
                panel.GetComponent<MenuPanelComponent>().Hide();
                transform.Find("ButtonPanel").Find(panel.name + "Button").Find("Image").gameObject.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        body.GetComponent<MeshRenderer>().materials[1].color = ColorDrone.mesh1Color;
    }
}
