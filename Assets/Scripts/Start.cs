using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public GameObject settingsMenu, coloursMenu, soundOn, soundOff, startButton, settings, colours;

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMenu(bool _settingsMenu, bool _coloursMenu, bool _startButton, bool _settings, bool _colours)
    {
        settingsMenu.SetActive(_settingsMenu);
        coloursMenu.SetActive(_coloursMenu); 
        startButton.SetActive(_startButton);
        settings.SetActive(_settings);
        colours.SetActive(_colours);
    }

    public void SettingsMenu()
    {
        StartMenu(true, false, false, false, false);
    }

    public void ColoursMenu()
    {
        StartMenu(false, true, false, false, false);
    }

    public void BackToMainMenu()
    { 
        StartMenu(false, false, true, true, true);
    }

    void SetColour(float R, float G, float B, float A)
    {
        PlayerPrefs.SetFloat("colourR", R);
        PlayerPrefs.SetFloat("colourG", G);
        PlayerPrefs.SetFloat("colourB", B);
        PlayerPrefs.SetFloat("colourA", A);
    }

    public void ChangeColour(int colourIndex)
    {
        switch(colourIndex)
        {
            case 1:
                SetColour(0.0756942f, 0.5943396f, 0.2351929f, 1f);
                break;
            case 2:
                SetColour(0.0756942f, 0.5686275f, 0.5960785f, 1f);
                break;
            case 3:
                SetColour(0.0756942f, 0.2588235f, 0.5960785f, 1f);
                break;
            case 4:
                SetColour(0.3372549f, 0.07450981f, 0.5960785f, 1f);
                break;
            case 5:
                SetColour(0.5960785f, 0.07450981f, 0.4039216f, 1f);
                break;
            case 6:
                SetColour(0.5960785f, 0.07450981f, 0.07450981f, 1f);
                break;
            case 7:
                SetColour(0.84f, 0.372f, 0.064f, 1f);
                break;
            case 8:
                SetColour(0.762f, 0.631f, 0.096f, 1f);
                break;
            case 9:
                SetColour(0.5607843f, 0.7333333f, 0.1176471f, 1f);
                break;
            default:
                SetColour(1f, 1f, 1f, 1f);
                break;
        }
    }

    public void SoundOff()
    {
        PlayerPrefs.SetString("Sound", "Off");
    }

    public void SoundOn()
    {
        PlayerPrefs.SetString("Sound", "On");
    }

    void FixedUpdate()
    {
        
        if(PlayerPrefs.GetString("Sound") == "Off")
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
        else
        {
            soundOff.SetActive(false);
            soundOn.SetActive(true);
        }

    }



  
}
