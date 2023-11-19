using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Visible : MonoBehaviour
{
    public TMP_InputField userPasswordEnter;
    public GameObject hideImage;
    public GameObject findImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateContentType()
    {
        if (userPasswordEnter.contentType == TMP_InputField.ContentType.Password)
        {
            userPasswordEnter.contentType = TMP_InputField.ContentType.Standard;
            hideImage.SetActive(false);
            findImage.SetActive(true);
        }
        else
        {
            userPasswordEnter.contentType = TMP_InputField.ContentType.Password;
            hideImage.SetActive(true);
            findImage.SetActive(false);
        }
        userPasswordEnter.ForceLabelUpdate();
    }
}
