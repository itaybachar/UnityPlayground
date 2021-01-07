using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test02 : MonoBehaviour
{
    public Transform objectTransform;
    public Camera gameCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(r,out hitInfo))
        {
            objectTransform.position = hitInfo.point;
            objectTransform.rotation = Quaternion.FromToRotation(Vector3.up,hitInfo.normal);
        }
    }
}
