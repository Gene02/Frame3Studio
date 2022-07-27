using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource music;

    public AudioSource[] soundEffect;

    private void Awake()
    {
        instance = this;
    }
   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void StopMusic()
    {
        music.Stop();
    }
}
