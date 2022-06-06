using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Music
{
    public string MusicID;
    public AudioClip clip;
    [HideInInspector] public AudioSource source;

    // Update is called once per frame
    void Update()
    {
        
    }
}
