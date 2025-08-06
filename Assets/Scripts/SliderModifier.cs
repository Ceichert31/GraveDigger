using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderModifier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText;
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void UpdateText()
    {
        sliderText.text = slider.value.ToString();
    }
}
