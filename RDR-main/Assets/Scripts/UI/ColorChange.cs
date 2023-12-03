using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChange : MonoBehaviour
{
    public GameObject body;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeOnClick(int number)
    {
        var color = GetComponent<Image>().color;
        body.GetComponent<MeshRenderer>().materials[number].color = color;
    }

}
