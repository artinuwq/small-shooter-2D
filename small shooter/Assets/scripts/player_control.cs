using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using TMPro;

public class player_control : MonoBehaviour
{
    public GameObject obj;
    public GameObject Lose;
    public GameObject TextTimerOBJ;
    public TMP_Text TextTimer;
    public TMP_Text LostTextTimer;
    public int Timer;
    public int level = 2;
    public bool GameStop;
    // 3 - Верх
    // 2 - Серидина
    // 1 - Низ
    public Animator animation_controller;
    void Start()
    {
        Invoke("TimerSC", 1);
    }

    // Update is called once per frame
    void Update()
    {
        TextTimerOBJ.SetActive(!Lose.activeSelf);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            if (level != 3) { level++; }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (level != 1) { level--; }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStop = !GameStop;
        }
        if (GameStop == true) {
            Time.timeScale = 0;
        } else if (GameStop == false)  { Time.timeScale = 1; }

        if (level == 1) { obj.transform.position = new Vector3(-5, -1.69f, 0); } else
       if (level == 2) { obj.transform.position = new Vector3(-5, 0.55f, 0); } else
      if (level == 3) { obj.transform.position = new Vector3(-5, 3.32f, 0); }
    }
    public void TimerSC() {
        if (Lose.activeSelf == false)
        {
            Timer++;
            Invoke("TimerSC", 1);
            TextTimer.text = Timer.ToString();
            LostTextTimer.text = "Время: " + Timer.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            Lose.SetActive(true);
            obj.transform.position = new Vector3(0, -10, 0);


        }
    }
}
