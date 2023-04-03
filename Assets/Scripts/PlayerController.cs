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
        bool canJump = jumpCooldown <= 0;

        // Jump
        if (canJump){            
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput){                
                Jump();                
            }
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
            Debug.Log("ponto");
            
        } else {
            // Game Over
            Debug.Log("Game Over");

            GameManager.Instance.isGameActive = false;
            
        }

    }

    private void Jump() {
        jumpCooldown = jumpInterval;

        thisRigidbody.velocity = Vector3.zero;         
        thisRigidbody.AddForce(new Vector3(0,jumpPower,0), ForceMode.Impulse);
    }
}
