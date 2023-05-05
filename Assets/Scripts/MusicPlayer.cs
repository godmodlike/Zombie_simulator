using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource m_audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.volume = PlayerPrefsController.GetVolume();
    }

    public void SetVolume(float volume)
    {
        m_audioSource.volume = volume;
    }
}
