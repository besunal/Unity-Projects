using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Collision1 : MonoBehaviour
{
    // bu asagida carpýsmalarýmýzýn sonuclarýný yapýyoruz mesela carptýk ne olacak falan fýlanÖ

    float leveldelay = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;

    AudioSource audioSource;

     bool isTransitioning=false;
    bool  collisionDisable=false;

    // audýo source u cache edebýlmek ýcýn starta ýhtýyacýmýz vardý.
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
     void Update()
    {
        // L ye bastýgýnda level degýssýn C ye bastýgýnda ýse basa
        RespondToDebugKeys();
          
    }
    // l ye bastýgýnda  nextlevela gec yan ýbýr sonraký levela
    //C ye bastýgýnda ýse collýsýonlarý kapat.
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
    {   // transitioning true ise asagidakýlerýn hýc býrýný yapma asagýya gecme.
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


    // Carpýsma durumunda hareket etmeyý durduran ve býr onceký levele 1 sanýye gec gýtmesýný saglayan fonksýyon
    void StartCrashSequence()
    {   
         isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);




        crashParticles.Play();
        GetComponent<Movements>().enabled = false;
        Invoke("ReloadLevel", leveldelay);
    }
    // basarýlý sekýlde ýnýs yaptýk býr sonraký levela gecmeyý arayan fonksýyon.
    void  StartSuccessSequence()
    {
        // true degerý ýle yukarda if blogunda artýk o switch dongusunu kullanmamasýný saglayarak ýkýncý kez seslerýn cýkmasýn
        // engelledýk mesela collision audio gibi
        // ardindan ise stopla thrust sesinin gelmesini engellemýs olduk.
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
    
    //guncel ýndexý al
    // býr sonraký ýndexý +1 ýle toplayarak yakala
    // kontrol et eger guncel ýndex tum ýndex sayýsý ýle esýtse  nextscene ýndex = olsun ký basa donebýlelým
    // nextscene ýndexe gore ýslemý yap
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
