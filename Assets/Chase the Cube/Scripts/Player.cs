using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 7.5f;

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        Vector3 vel = input.normalized*speed;
        Vector3 moveAmount = vel*Time.deltaTime;

        transform.Translate(moveAmount);
    }
}
