using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public GameObject prefab1;
    public Vector3 Pos1 = new Vector3(15, 3.28f, 0);
    public Vector3 Pos2 = new Vector3(15, 0.55f, 0);
    public Vector3 Pos3 = new Vector3(15,-1.66f, 0);
    public GameObject LosePhone;

    public Vector3 Pos = new Vector3(15, 3.28f, 0);
    void Start()
    {
        Invoke("SpawnEnemy", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemy() {
        int HUIBLYAT = Random.Range(-1, 2);
        if (HUIBLYAT == 0) { Pos = Pos1; } else
        if (HUIBLYAT == 1) { Pos = Pos2; } else
        if (HUIBLYAT == 2) { Pos = Pos3; }

        Instantiate(prefab1, Pos, Quaternion.identity);
        if (LosePhone.activeSelf == false) { Invoke("SpawnEnemy", Random.Range(0.3f, 4)); }
    }
}
