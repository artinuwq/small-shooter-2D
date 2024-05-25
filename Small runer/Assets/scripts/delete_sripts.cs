using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_sripts : MonoBehaviour
{
    public int DeleteTime;
    void Start()
    {
        Invoke("Delete",DeleteTime);
    }

    // Update is called once per frame
    void Delete()
    {
        Destroy(gameObject);
    }
}
