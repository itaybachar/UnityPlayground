using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform targetTransform;

    float speed = 5;
    // Update is called once per frame
    void Update()
    {
        Vector3 chaseDir = targetTransform.position - transform.position;
        chaseDir.y = 0;
        Vector3 vel = chaseDir.normalized*speed;
        Vector3 moveAmount = vel*Time.deltaTime;

        if(chaseDir.magnitude > 1.75f)
        {
            transform.Translate(moveAmount);
        }
    }
}
