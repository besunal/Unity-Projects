using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    // Start is called before the first frame update
    public float Upspeed;
    int score = 0;
    AudioSource audiosource;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(0, Upspeed, 0);
    }

    private void OnMouseDown()
    {
        score++;
        audiosource.Play();
    }

    private void Reset()
    {
        
    }

}
