using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidbody;
    public float jumpPower = 0.3f;
    public float jumpInterval = 0.5f;
    public float jumpCooldown = 0;

    public float movingSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        // Uppdate cooldown
        jumpCooldown -= Time.deltaTime;
        bool isGameActive = GameManager.Instance.IsGameActive();
        bool canJump = jumpCooldown <= 0 && isGameActive;

        // Jump
        if (canJump){            
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput){                
                Jump();                
            }
        } 

        //Toggle gravity
        thisRigidbody.useGravity = isGameActive; 

        // Freeze Rigidbody if game is over
        if(!isGameActive) {
            thisRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        }        
        
    }

    void OnCollisionEnter(Collision other) {
        OnCustomCollisionEnter(other.gameObject);
    }

    void OnTriggerEnter(Collider other) {
        OnCustomCollisionEnter(other.gameObject);        
    }

    private void OnCustomCollisionEnter(GameObject other) {
        bool isSensor = other.CompareTag("Sensor");
        if (isSensor) {
            GameManager.Instance.score++;
            Debug.Log("Placar: "+GameManager.Instance.score);
            if(GameManager.Instance.score%10 == 0 && GameManager.Instance.score !=0) {
                GameManager.Instance.obstacleSpeed = GameManager.Instance.obstacleSpeed * 1.3f; 
            }
            
        } else {
            // Game Over
            GameManager.Instance.EndGame();         
        }
    }

    private void Jump() {
        jumpCooldown = jumpInterval;

        thisRigidbody.velocity = Vector3.zero;         
        thisRigidbody.AddForce(new Vector3(0,jumpPower,0), ForceMode.Impulse);
    }
}
