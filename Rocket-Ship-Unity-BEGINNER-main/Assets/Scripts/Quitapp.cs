using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitapp : MonoBehaviour
{
    // QUIT GAME
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape the game");
            Application.Quit();
        }
    }
}
