using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objecthit : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        // eger player tagýna sahýp kýsý carparsa rengýný kýrmýzý yap ve ýlgýlý objenýn tagýný hýt yap
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";

        }
        

    }
}
