using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-10 * Time.deltaTime, 0, 0);
            if (transform.position.x < -30.54) { transform.position = new Vector3(20, 1.27f, 2); }
    }
}
