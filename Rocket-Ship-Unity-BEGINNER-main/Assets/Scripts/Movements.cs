using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    Rigidbody rb;

    
    float mainThrust = 1000f;
    float rotationThrust = 150f;
    [SerializeField] AudioClip Thruster;

    [SerializeField] ParticleSystem rocketJet;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        ProcessThrust();
        ProcessRotation();
    }

    // roketý ateslemek ýcýn olan kod blogu
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        } // oteký durumlarda calma dursun
        else
        {
            StopThrusting();

        }
    }

    
    // thrusting rocket
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        // audio source calmýyorsa thrustta cal
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(Thruster);
        }
        if (!rocketJet.isPlaying)
        {
            rocketJet.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        rocketJet.Stop();
    }

    //sag ve sola yon vermek ýcýn Z eksenýný kullandýk yaný up
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }
     // clean code ýcýn bu sekýlde yazmak her zaman daha iyi yukarýda da kullandýk
      public void ApplyRotation(float rotationThisFrame)
    {    // þimdi roket bir yere çarptýðý zaman biz A ve D kontrollerýný kaybediyoruz,bunu onlememýz lazým
        // bunu onlemek ýcýn booleanlarý kullanacagýz.
        // burada temel olarak soyledýgýmýz sen RIGIDBODY de olan fizik sistemini durdur 
        // ben kendý fýzýk sýstemýmý kullanayým sonra tekrardan ben false yapayým sen kullan gari
        rb.freezeRotation = true; // we can manually rotate because freezerotation is true
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;

    } 
}
