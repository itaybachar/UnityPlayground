using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test01 : MonoBehaviour
{
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position,transform.forward);
        RaycastHit rayInfo;
        if(Physics.Raycast(r, out rayInfo,100,mask,QueryTriggerInteraction.Ignore))
        {
            Destroy(rayInfo.collider.gameObject);
            Debug.DrawLine(r.origin,rayInfo.point,Color.red);
        }
        else
        {
            Debug.DrawLine(r.origin,r.origin + r.direction*100,Color.green);
        }
    }
}
