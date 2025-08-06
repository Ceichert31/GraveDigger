using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum SliderState
{
    Sensitivity,
    Master,
    Ambient,
    SFX,
}
public class SliderSettings : MonoBehaviour
{
    [SerializeField] private SliderState sliderSetting;

    private Slider slider;

    private string playerPrefID;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        switch (sliderSetting)
        {
            case SliderState.Sensitivity:
                playerPrefID = "Sensitivity";
                break;
            case SliderState.Master:
                playerPrefID = "Master";
                break;
            case SliderState.Ambient:
                playerPrefID = "Ambient";
                break;
            case SliderState.SFX:
                playerPrefID = "SFX";
                break;
        }
    }

    public void UpdateSettings()
    {
        PlayerPrefs.SetInt(playerPrefID, ((int)slider.value));
    }
}
