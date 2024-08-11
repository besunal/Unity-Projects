using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objecthit : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        // eger player tag�na sah�p k�s� carparsa reng�n� k�rm�z� yap ve �lg�l� objen�n tag�n� h�t yap
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";

        }
        

    }
}
