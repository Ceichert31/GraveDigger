﻿using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace PSX
{
    public class FogController : MonoBehaviour
    {
        [SerializeField] protected VolumeProfile volumeProfile;
        [SerializeField] protected bool isEnabled = true;

        protected private GameManager gameManager;

        protected Fog fog;
        
        [Range(0,50)]
        [SerializeField] protected float fogDensity = 1.0f;
        [Range(0,1000)]
        [SerializeField] protected float fogDistance = 10.0f;
        [Range(0,100)]
        [SerializeField] protected float fogNear = 1.0f;
        [Range(0,100)]
        [SerializeField] protected float fogFar = 100.0f;
        [Range(0,100)]
        [SerializeField] protected float fogAltScale = 10.0f;
        [Range(0,1000)]
        [SerializeField] protected float fogThinning = 100.0f;
        [Range(0,1000)]
        [SerializeField] protected float noiseScale = 100.0f;
        [Range(0,1)]
        [SerializeField] protected float noiseStrength = 0.05f;
        
        [SerializeField] protected Color fogColor;
        [SerializeField] protected Color ambientColor;

        [SerializeField] protected Color deathFog;

        public float getFogDistance => fogDistance;
        public float setFogDistance(float value) => fogDistance = value;

        protected void Awake()
        {
            gameManager = GetComponent<GameManager>();
        }

        protected void Update()
        {
            this.SetParams();
            if (gameManager._points > 3 || gameManager._points <= 0)
                fog.fogColor.value = fogColor;
            else
                fog.fogColor.value = deathFog;
        }

        protected void SetParams()
        {
            if (!this.isEnabled) return; 
            if (this.volumeProfile == null) return;
            if (this.fog == null) volumeProfile.TryGet(out fog);
            if (this.fog == null) return;
            
            
            this.fog.fogDensity.value = this.fogDensity;
            this.fog.fogDistance.value = this.fogDistance;
            this.fog.fogNear.value = this.fogNear;
            this.fog.fogFar.value = this.fogFar;
            this.fog.fogAltScale.value = this.fogAltScale;
            this.fog.fogThinning.value = this.fogThinning;
            this.fog.noiseScale.value = this.noiseScale;
            this.fog.noiseStrength.value = this.noiseStrength;
            this.fog.ambientColor.value = this.ambientColor;

            //ACCESSING PARAMS 
            // this.fog.parameters.value
        }
    }
}