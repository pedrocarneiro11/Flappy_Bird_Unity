using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [HideInInspector]
    public int score;
    private bool isGameOver = false;
    public int RestartDelay = 2;

    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
    }
    public bool IsGameActive(){
        return !isGameOver;
    }

    public bool IsGameOver(){
        return isGameOver;
    }


    public void EndGame(){
        isGameOver = true;

        Debug.Log("Game Over, seu placar final é: "+GameManager.Instance.score);

        StartCoroutine(ReloadScene(RestartDelay));
    }

    private IEnumerator ReloadScene(float delay) {
        // Esperar X segundos (delay)
        yield return new WaitForSeconds(delay);

        // Recarregar a cena
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload scene");
        
    }
}
