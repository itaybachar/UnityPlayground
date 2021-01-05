using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2 speedMinMax;

    float speed;
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x,speedMinMax.y,Difficulty.GetDifficultyPercent());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime,Space.Self);

        if(transform.position.y < -Camera.main.orthographicSize - transform.localScale.y)
            Destroy(this.gameObject);
    }
}
