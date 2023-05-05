using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider m_volumeSlider;
    [SerializeField] private float m_defaultVolume = 0.8f;
    [SerializeField] private Slider m_difficultySlider;
    [SerializeField] private float m_defaultDifficulty = 1f;

    private void Awake()
    {
        m_volumeSlider.value = PlayerPrefsController.GetVolume();
        m_difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(m_volumeSlider.value);
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetVolume(m_volumeSlider.value);
        PlayerPrefsController.SetDifficulty(m_difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadNextScene(0);
    }

    public void SetDefaults()
    {
        m_volumeSlider.value = m_defaultVolume;
        m_difficultySlider.value = m_defaultDifficulty;
    }
}
