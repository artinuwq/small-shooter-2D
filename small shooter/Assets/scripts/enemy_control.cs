using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(Random.Range(-0.02f,-0.001f), 0, 0) ;
        if (transform.position.x < -15) { Destroy(gameObject); }
    }
}
