using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance;
        cooldown -= Time.deltaTime;
        
        if (cooldown <= 0f) 
        {
            cooldown = gameManager.obstacleInterval;

            // Spawn object
            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);

            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];

            float x = gameManager.obstacleOffsetX;
            float y = Random.Range(gameManager.ObstacleOffsetY.x,gameManager.ObstacleOffsetY.y);
            float z= 0;

            Vector3 position = new Vector3(x,y,z);
            Quaternion rotation = prefab.transform.rotation;

            Instantiate(prefab, position, rotation);
        }
        
    }
}
