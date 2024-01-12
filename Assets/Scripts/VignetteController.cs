using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
[ExecuteInEditMode]
public class VignetteController : MonoBehaviour
{
    [SerializeField] protected VolumeProfile profile;

    protected Vignette vignette;

    [SerializeField] protected bool isEnabled = true;

    [SerializeField] protected float vignetteIntensity;

    [SerializeField] protected Color vignetteColor;
    protected void Awake()
    {
        profile = GetComponent<Volume>().profile;
    }
    protected void Update()
    {
        SetParamaters();
    }
    protected void SetParamaters()
    {
        if (!isEnabled) return;
        if (profile == null) return;

        //Get vignette 
        if (vignette == null) profile.TryGet(out vignette);
        if (vignette == null) return;

        //Set Values
        vignette.intensity.value = vignetteIntensity;
        vignette.color.value = vignetteColor;
    }
}
