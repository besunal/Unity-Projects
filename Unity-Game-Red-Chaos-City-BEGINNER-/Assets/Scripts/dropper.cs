using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dropper : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float timeToWait = 5f;
    MeshRenderer  renderer;
    Rigidbody rigidbody;
    AudioSource clip;
    
    void Start()
    {
       // obje yukarýdan asagýya dusuyor duserken  bellý býr zamandan sonra dusmesýný saglýyoruz
      renderer=GetComponent<MeshRenderer>();
      rigidbody = GetComponent<Rigidbody>();
      clip = GetComponent<AudioSource>();
        
      renderer.enabled=false;
      rigidbody.useGravity = false;
      clip.enabled = false;



      

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToWait)
        {
            rigidbody.useGravity = true;
            renderer.enabled = true;
            clip.enabled = true;
            
        }
    }
}
