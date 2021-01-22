using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moveplayer : MonoBehaviour
{
    public AudioSource MusicSource;

    public AudioClip MusicBG;
    public AudioClip MusicaWin;
    public AudioClip MusicLose;

    public Text Resulttext;
    public Text Redotext;

    public float timeLeft = 12.0f;
    public Text TimeText; // used for showing countdown from 3, 2, 1 
    private bool timerIsActive=true;

    private bool PlayerRedo=false;
    private bool CanMove=true;



    void Start()
    {
        Resulttext.text = "";
        Redotext.text = "";
        MusicSource.clip = MusicBG;
        MusicSource.Play();
    }


    void Update()
    {   
        if (CanMove==true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal")*10f, Input.GetAxis("Vertical")*10f);
        }
        if(timerIsActive)
        {
            timeLeft -= Time.deltaTime;
            TimeText.text = (timeLeft).ToString("0");
            if (timeLeft <= 0)
            {
                //Do something useful or Load a new game scene depending on your use-case
                TimeText.text = "0";
                timerIsActive=false;
                GameLose();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (PlayerRedo == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        if (CanMove==false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal")*0f, Input.GetAxis("Vertical")*0f);
        }
    }


    public void GameLose()
    {
        MusicSource.Stop();
        PlayerRedo=true;
        CanMove=false;
        Resulttext.text = "You Lose. Game Over!";
        Redotext.text = "R - Restart | ESC - Quit";
        MusicSource.clip = MusicLose;
        MusicSource.Play();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "flag")
        {
            timerIsActive=false;
            PlayerRedo=true;
            CanMove=false;
            Resulttext.text = "You Win! Game Over!";
            Redotext.text = "R - Restart | ESC - Quit";
            MusicSource.Stop();
            MusicSource.clip = MusicaWin;
            MusicSource.Play();
        }
    }
}

