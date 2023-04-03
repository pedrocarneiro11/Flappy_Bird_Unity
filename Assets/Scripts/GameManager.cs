using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    // Intervalo da altura deve ser -2,6 <= Y <= 3.6
    public static GameManager Instance {get; private set;}

    [HideInInspector]
    public bool isGameActive = true;
    
    [FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;
    public float obstacleInterval = 1;
    public float obstacleSpeed = 10;
    public float obstacleOffsetX = 0;
    public Vector2 ObstacleOffsetY = new Vector2(0,0);

    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
    }
}
