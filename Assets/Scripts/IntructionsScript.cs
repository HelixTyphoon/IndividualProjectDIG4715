using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntructionsScript : MonoBehaviour
{
    public AudioSource MusicSource;

    public AudioClip MusicStart;
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicStart;
        MusicSource.Play();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
