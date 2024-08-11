using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 10f;
    [SerializeField]float yValue = 0.02f;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       movePlayer();
    }


    void movePlayer()
    {
        float X = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float Z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(X, 0f, Z);
    }
}
