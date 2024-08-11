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

    // roket� ateslemek �c�n olan kod blogu
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        } // otek� durumlarda calma dursun
        else
        {
            StopThrusting();

        }
    }

    
    // thrusting rocket
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        // audio source calm�yorsa thrustta cal
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

    //sag ve sola yon vermek �c�n Z eksen�n� kulland�k yan� up
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
     // clean code �c�n bu sek�lde yazmak her zaman daha iyi yukar�da da kulland�k
      public void ApplyRotation(float rotationThisFrame)
    {    // �imdi roket bir yere �arpt��� zaman biz A ve D kontroller�n� kaybediyoruz,bunu onlemem�z laz�m
        // bunu onlemek �c�n booleanlar� kullanacag�z.
        // burada temel olarak soyled�g�m�z sen RIGIDBODY de olan fizik sistemini durdur 
        // ben kend� f�z�k s�stem�m� kullanay�m sonra tekrardan ben false yapay�m sen kullan gari
        rb.freezeRotation = true; // we can manually rotate because freezerotation is true
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;

    } 
}
