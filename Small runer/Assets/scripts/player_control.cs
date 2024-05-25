using UnityEngine;
using TMPro;
using static Library;


public class player_control : MonoBehaviour
{
    public GameObject obj;
    public GameObject Lose;
    public GameObject TextTimerOBJ;
    public GameObject PauseMenu;
    public bool PauseMenuActivited = true;
    public TMP_Text TextTimer;
    public TMP_Text LostTextTimer;
    public int Timer;
    public int level = 2;
    public bool GameStop;
    public float XposOffset = 0;
    // 3 - Верх
    // 2 - Серидина
    // 1 - Низ
    public Animator animation_controller;
    void Start()
    {
        StaticHolder.CurrentlyDiffucult = 1;
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
            PauseMenuF();
        } else if (GameStop == false) {
            UNPauseMenuF();
        }

        if (Input.GetAxisRaw("Horizontal") > 0 && XposOffset < 3)
        {
            XposOffset += Input.GetAxisRaw("Horizontal") * 3 * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 && XposOffset > -3)
        {
            XposOffset += Input.GetAxisRaw("Horizontal") * 3 * Time.deltaTime;

        } 



            if (level == 1) { obj.transform.position = new Vector3(-4 + XposOffset, -1.69f, 0); } else
       if (level == 2) { obj.transform.position = new Vector3(-4 + XposOffset, 0.55f, 0); } else
      if (level == 3) { obj.transform.position = new Vector3(-4 + XposOffset, 3.32f, 0); }
    }
    public void TimerSC() {
        if (Lose.activeSelf == false)
        {
            Timer++;
            Invoke("TimerSC", 1);
            TextTimer.text = Timer.ToString();
            LostTextTimer.text = "Время: " + Timer.ToString();
            StaticHolder.CurrentlyDiffucult = Timer; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            LoseMenu();
        }
    }


    public void LoseMenu() {
        Lose.SetActive(true);
        PauseMenu.SetActive(false);
        obj.transform.position = new Vector3(0, -10, 0);
        if (Timer > StaticHolder.MaxTime) { StaticHolder.MaxTime = Timer; }
        PauseMenuActivited = false;
    }
    public void PauseMenuF()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true && PauseMenuActivited);

    }
    public void UNPauseMenuF()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false && PauseMenuActivited);
        GameStop = false;
    }
}
