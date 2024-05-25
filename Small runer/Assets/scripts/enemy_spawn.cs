using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public GameObject prefab1, PrefabRayDeath, prefabRayUp, prefabDangerousUp;
    public GameObject LosePage;
    public int LocalPlayt;
    public int EveLin;
    public GameObject[] DangerousC = new GameObject[3];
    Vector3 ELpos = new Vector3(15, 3.28f, 0);
    public int CE = 0;
    Vector3 Pos = new Vector3(15, 3.28f, 0);
    void Start()
    {
        Invoke("SpawnEnemy", 2);
        Invoke("RandomEvent", Random.Range(1,2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy() {
        int HUIBLYAT = Random.Range(0, 3);
        if (HUIBLYAT == 0) { Pos = new Vector3(15, 3.28f, 0); } else
        if (HUIBLYAT == 1) { Pos = new Vector3(15, 0.55f, 0); } else
        if (HUIBLYAT == 2) { Pos = new Vector3(15, -1.87f, 0); }
        //
        Instantiate(prefab1, Pos, Quaternion.identity);
        if (LosePage.activeSelf == false) { Invoke("SpawnEnemy", Random.Range(0.3f, 4)); }
    }

    public void RandomEvent() {
        LocalPlayt = Random.Range(0, 3);
        if (LocalPlayt == 0) { ELpos = new Vector3(0, 3.72f, 0); }
        else if (LocalPlayt == 1) { ELpos = new Vector3(0, 0.85f, 0); }
        else if (LocalPlayt == 2) { ELpos = new Vector3(0, -1.66f, 0); }


        
        int REC = Random.Range(0, 2);
        if (REC==1) {
            CE = 0;
            Invoke("RayDeath", 3);
        } 
        else
        if (REC == 0)
        {
            CE = 0;
            Invoke("UpDeath", 2);
        }
        


    }

    public void RayDeath() {
        
        if (CE == 0) { DangerousC[LocalPlayt].SetActive(true); }
        if (CE == 1) { DangerousC[LocalPlayt].SetActive(false); }
        if (CE == 3) { DangerousC[LocalPlayt].SetActive(true); }
        if (CE == 4) { DangerousC[LocalPlayt].SetActive(false); }
        if (CE == 5) {
            Instantiate(PrefabRayDeath, ELpos, Quaternion.identity);
            Invoke("RandomEvent", 5);
        }
        if (CE != 5) { Invoke("RayDeath", 1); }
        CE++;
    }


    public void UpDeath()
    {
        Vector3 UDpos = new Vector3(-1, 4.3f, 0);
             if (LocalPlayt == 0) { UDpos = new Vector3(-4, 4.3f, 0); }
        else if (LocalPlayt == 1) { UDpos = new Vector3(-1, 4.3f, 0); }
        else if (LocalPlayt == 2) { UDpos = new Vector3(-7, 4.3f, 0); }

        if (CE == 0) { Instantiate(prefabDangerousUp, UDpos, Quaternion.identity); }
        if (CE == 3) { Instantiate(prefabDangerousUp, UDpos, Quaternion.identity); }
        if (CE == 5)
         {
            Instantiate(prefabRayUp, UDpos, Quaternion.identity);
            Invoke("RandomEvent", 5);
        }
        if (CE != 5) { Invoke("UpDeath", 1); }
        CE++;
    }
}
