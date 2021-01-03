using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerGame : MonoBehaviour
{
    public float AcceptedRange = 1.5f;

    float startTime;
    int goalTime;
    int roundDelay = 3;
    bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        print("Press the space bar when you think the displayed time has passed!");
        Invoke("SetNewRandomTime",roundDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gameStarted)
        {
            gameStarted = false;    
            if(RandomCrash())
            {
                print("You pressed Space wrong... You broke the game!");
                print("Seriously how do u fuck that up?");
                print("Restarting...");
            }
            else
            {
            
                float waitTime = Time.time-startTime;
                float err = Mathf.Abs(waitTime-goalTime);

                print("You waited for " + waitTime + " seconds. That's " + err + " seconds off.");
            
                if(err<=AcceptedRange)
                {
                    print("You Win!");
                }
                
            } 
            Invoke("SetNewRandomTime",roundDelay);
        }
    }

    bool RandomCrash()
    {
        return (0.48f>Random.Range(0.0f,1.0f));
    }

    void SetNewRandomTime()
    {
        gameStarted = true;
        startTime = Time.time;
        goalTime = Random.Range(5,22);
        print("Goal Time: " + goalTime + " seconds.");
    }
}
