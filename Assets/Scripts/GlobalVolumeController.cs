using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[ExecuteInEditMode]
public class GlobalVolumeController : MonoBehaviour
{
    [SerializeField] protected VolumeProfile volumeProfile;
    [SerializeField] protected bool isEnabled = true;

    protected ChromaticAberration chrome;
    protected LensDistortion distortion;

    //Chromatic Aberration
    [Range(0, 1)]
    [SerializeField] protected float intensity;

    //Lens Distortion
    [Range(-1, 1)]
    [SerializeField] protected float strength;

    [Range(0, 5)]
    [SerializeField] protected float scale;

    protected void Awake()
    {
        volumeProfile = GetComponent<Volume>().profile;
    }
    protected void Update()
    {
        SetParams();
    }
    protected void SetParams()
    {
        if (!isEnabled) return;
        if (volumeProfile == null) return;

        //Try to get specified Global Volume compnents
        if (chrome == null) volumeProfile.TryGet(out chrome);
        if (chrome == null) return;

        if (distortion == null) volumeProfile.TryGet(out distortion);
        if (distortion == null) return;

        //Set Chromatic values
        chrome.intensity.value = intensity;

        //Set Lens values
        //distortion.intensity.value = strength;
        distortion.scale.value = scale;
    }
}
