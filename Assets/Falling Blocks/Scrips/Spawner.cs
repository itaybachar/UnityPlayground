using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingEntityPrefab;
    public Vector2 spawnTimeMinMax;
    float nextSpawnTime;

    public float maxSpawnSize; 
    public float maxSpawnAngle;

    Vector2 screenHalfSize;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect*Camera.main.orthographicSize,Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > nextSpawnTime)
        {  
            float secondsBetweenSpawns = Mathf.Lerp(spawnTimeMinMax.y,spawnTimeMinMax.x,Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            
            float halfSpawnRange = screenHalfSize.x - fallingEntityPrefab.transform.localScale.x/2;
            
            Vector2 spawnPosition = new Vector2(Random.Range(-halfSpawnRange, halfSpawnRange),screenHalfSize.y);
            float spawnAngle = Random.Range(-maxSpawnAngle,maxSpawnAngle);
            float spawnSize = Random.Range(0.3f,maxSpawnSize);
            
            GameObject entity = (GameObject)Instantiate(fallingEntityPrefab,spawnPosition,Quaternion.Euler(Vector3.forward*spawnAngle));
            entity.transform.localScale = Vector2.one * spawnSize;

        }
    }
}
