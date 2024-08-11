using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Collision1 : MonoBehaviour
{
    // bu asagida carp�smalar�m�z�n sonuclar�n� yap�yoruz mesela carpt�k ne olacak falan f�lan�

    float leveldelay = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;

    AudioSource audioSource;

     bool isTransitioning=false;
    bool  collisionDisable=false;

    // aud�o source u cache edeb�lmek �c�n starta �ht�yac�m�z vard�.
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
     void Update()
    {
        // L ye bast�g�nda level deg�ss�n C ye bast�g�nda �se basa
        RespondToDebugKeys();
          
    }
    // l ye bast�g�nda  nextlevela gec yan �b�r sonrak� levela
    //C ye bast�g�nda �se coll�s�onlar� kapat.
   void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            nextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable; // toggle collision
        }
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {   // transitioning true ise asagidak�ler�n h�c b�r�n� yapma asag�ya gecme.
        if (isTransitioning || collisionDisable) { return; }

        switch (collision.gameObject.tag)
        {

            case "Friendly":
                Debug.Log("This thing is friendly");
                break;

            case "Finish":
                StartSuccessSequence();
                break;



            

            default:
                StartCrashSequence();
                break;
        }
    }


    // Carp�sma durumunda hareket etmey� durduran ve b�r oncek� levele 1 san�ye gec g�tmes�n� saglayan fonks�yon
    void StartCrashSequence()
    {   
         isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);




        crashParticles.Play();
        GetComponent<Movements>().enabled = false;
        Invoke("ReloadLevel", leveldelay);
    }
    // basar�l� sek�lde �n�s yapt�k b�r sonrak� levela gecmey� arayan fonks�yon.
    void  StartSuccessSequence()
    {
        // true deger� �le yukarda if blogunda art�k o switch dongusunu kullanmamas�n� saglayarak �k�nc� kez sesler�n c�kmas�n
        // engelled�k mesela collision audio gibi
        // ardindan ise stopla thrust sesinin gelmesini engellem�s olduk.
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(finish);
        finishParticles.Play();
        GetComponent<Movements>().enabled = false;
        Invoke("nextLevel", leveldelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    //guncel �ndex� al
    // b�r sonrak� �ndex� +1 �le toplayarak yakala
    // kontrol et eger guncel �ndex tum �ndex say�s� �le es�tse  nextscene �ndex = olsun k� basa doneb�lel�m
    // nextscene �ndexe gore �slem� yap
    void nextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) 
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
