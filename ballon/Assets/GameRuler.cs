using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Balon;
    public Transform SourcePosition;
    public float maxX;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballonthrow=SourcePosition.position;
        ballonthrow.x = Random.Range(-maxX,maxX);
        Instantiate(Balon, ballonthrow, Quaternion.identity);
    }
}
