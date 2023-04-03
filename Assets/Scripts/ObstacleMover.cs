using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move Object
        float x = GameManager.Instance.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x,0,0);  

        // Destroy Object
        if (transform.position.x <= -GameManager.Instance.obstacleOffsetX) 
        {
            Destroy(gameObject);
        }     
    }
}
