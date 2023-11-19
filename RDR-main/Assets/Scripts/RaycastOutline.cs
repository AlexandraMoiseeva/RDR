using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastOutline : MonoBehaviour
{
    public Camera userCamera;
    private float _rayDistance = 400f;
    Outline lastOutlineObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(userCamera.transform.position, 
            userCamera.transform.forward, out hit, _rayDistance))
        {
            /*Debug.DrawRay(userCamera.transform.position,
            userCamera.transform.forward * hit.distance,
            Color.green);*/

            if (hit.transform.gameObject.CompareTag("Detail"))
            {
                lastOutlineObject = hit.transform.gameObject.GetComponent<Outline>();
                lastOutlineObject.enabled = true;
            }
            else
            {
                if (lastOutlineObject != null)
                    lastOutlineObject.enabled = false;
            }
        }
        else 
        {
            Debug.DrawRay(userCamera.transform.position,
            userCamera.transform.forward * _rayDistance,
            Color.green);
        }
    }
}
