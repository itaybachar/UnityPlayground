using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event System.Action OnPlayerDeath;

    float speed = 7.5f;
    float screenWorldHalfWidth = 7.5f;
    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerSize = transform.localScale.x/2;
        screenWorldHalfWidth = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerSize;   
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float vel = input * speed;

        transform.Translate(Vector2.right * vel * Time.deltaTime);

        if(transform.position.x < -screenWorldHalfWidth)
        {
            transform.position = new Vector2(screenWorldHalfWidth,transform.position.y);
        } 
        else if(transform.position.x > screenWorldHalfWidth)
        {
            transform.position = new Vector2(-screenWorldHalfWidth,transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Falling Entity")
        {
            if(OnPlayerDeath != null)
                OnPlayerDeath();
            Destroy(gameObject);    
        }
    }
}
