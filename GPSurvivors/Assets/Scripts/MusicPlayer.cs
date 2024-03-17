using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private string musicTrack = "Earth";

    void Start()
    {
        FindObjectOfType<SoundManager>().PlayMusicTrack(this.musicTrack);
    }
}
