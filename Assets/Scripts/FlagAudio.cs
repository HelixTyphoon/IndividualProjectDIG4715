using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAudio : MonoBehaviour
{
    public AudioSource MusicSource;

    public AudioClip MusicFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            MusicSource.clip = MusicFlag;
            MusicSource.Play();
        }
    }
}
