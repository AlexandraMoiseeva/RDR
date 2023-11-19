using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R1R2Script : MonoBehaviour
{
    public List<Animator> MainMenuButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton(int buttonsNumber)
    {
        for (int i = buttonsNumber; i < MainMenuButton.Count; ++i)
        {
            //MainMenuButton[i].SetTrigger("Highlighted");
            MainMenuButton[i].SetTrigger("Pressed");
        }

        for(int i = 0; i < buttonsNumber; ++i)
        {
            MainMenuButton[i].SetTrigger("Normal");
        }
    }
}
