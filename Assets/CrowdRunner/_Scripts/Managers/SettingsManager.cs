using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    /*---Elements---*/
    [SerializeField] private HapticsManager hapticsManager;
    [SerializeField] private SoundsManager soundManager;
    [SerializeField] private Sprite  optionsOnSprite;
    [SerializeField] private Sprite optionsOffSprite;
    [SerializeField] private Image soundsButtonImage;
    [SerializeField] private Image hapticsButtonImage;
    
    /*---SoundState---*/
    private bool soundsState = true;
    private bool hapticsState = true ;

    private void Awake()
    {
        soundsState = PlayerPrefs.GetInt("sounds", 1) == 1;
        hapticsState = PlayerPrefs.GetInt("haptics", 1) == 1;
    }

    void Start()
    {
       Setup();
    }

    private void Setup()
    {
        if (soundsState)
        {
        EnableSounds();
        }
        else
        {
            DisableSounds();
        }
        if (hapticsState)
        {
            EnableSounds();
        }
        else
        {
            DisableSounds();
        }
    }
    /*Sounds*/
    private void DisableSounds()
    {
        soundManager.DisableSounds();
        soundsButtonImage.sprite = optionsOffSprite;
    }

    private void EnableSounds()
    {
        soundManager.EnableSounds();
        soundsButtonImage.sprite = optionsOnSprite;
    }
    /*haptics*/
    private void DisableHaptics()
    {
        hapticsManager.DisableHaptic();

        hapticsButtonImage.sprite = optionsOffSprite;
    }

    private void EnableHaptics()
    {
        hapticsManager.EnableHaptic();

        hapticsButtonImage.sprite = optionsOnSprite;
    }
    
    public void ChangehapticState()
    {
        if (hapticsState)
        {
            DisableHaptics();
        }
        else
        {
            EnableHaptics();
        }

       hapticsState = !hapticsState;
       PlayerPrefs.SetInt("haptics", hapticsState?1:0 );
    }
    public void ChangeSoundState()
    {
        if (soundsState)
        {
            DisableSounds();
        }
        else
        {
            EnableSounds();
        }

        soundsState = !soundsState;
        PlayerPrefs.SetInt("sounds", soundsState?1:0 );
       
    }

    
}
