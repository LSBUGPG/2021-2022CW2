using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private string currentMusicID;
    public Music[] musics;
    public Text CurrentMusicPlayingText;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach (Music m in musics)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
        }
    }

    // Update is called once per frame
    public void ChangeMusic(string NewMusicID)
    {
        foreach (Music m in musics)
        {
            if (m.MusicID == currentMusicID)
            {
                m.source.Stop();
                break;
            }
        }

        currentMusicID = NewMusicID;

        foreach (Music m in musics)
        {
            if (m.MusicID == currentMusicID)
            {
                m.source.Play();
                break;
            }
        }

        CurrentMusicPlayingText.text = "Currently Playing: " + currentMusicID;
    }
}
