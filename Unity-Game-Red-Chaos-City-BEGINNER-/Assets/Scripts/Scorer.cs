using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] int score;

    private void OnCollisionEnter(Collision collision)
    {
         //eger ilgili objeye daha once carpýlmamýssa score vurulma sayýsýný arttýr
        if (collision.gameObject.tag != "Hit")
        {
            score++;
            Debug.Log($"you bumped in {score} times");
        }
       
        
    }
}
