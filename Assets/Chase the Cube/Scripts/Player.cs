using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 7.5f;

    Vector3 velocity;
    Rigidbody myRb;
    bool jump = false;

    void Start(){
        myRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0 ,Input.GetAxisRaw("Vertical"));
        velocity = input.normalized*speed;
        velocity.y = Input.GetAxisRaw("Jump")*speed;
        if(jump)
        {
            velocity.y = 5*speed;
            jump = !jump;
        }
    }

    void FixedUpdate() {
        myRb.position += velocity * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            Destroy(other.gameObject);
            jump = true;
        }
    }
}
