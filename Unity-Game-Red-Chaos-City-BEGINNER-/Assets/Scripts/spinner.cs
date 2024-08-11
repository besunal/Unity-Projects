using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinner : MonoBehaviour
{
    
    [SerializeField] float Xrotate=0;
    [SerializeField] float Yrotate=0;
    [SerializeField] float Zrotate=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Xrotate,Yrotate,Zrotate);
    }
}
