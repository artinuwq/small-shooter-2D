using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Library;

public class enemy_control : MonoBehaviour
{
    public TMP_Text InfoTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3((-6f * (StaticHolder.CurrentlyDiffucult / 10f)) * Time.deltaTime, 0, 0) ;
        if (transform.position.x < -15) { Destroy(gameObject); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
          
        }
    }
}
