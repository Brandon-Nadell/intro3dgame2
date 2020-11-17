using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
    [ExecuteInEditMode]
    public class SunSkybox : MonoBehaviour
    {
        public Material skyboxMaterial;
        int sunDirId, sunColorId;
        Light sun;
        int timer = 0;
        public Color sky;
        public Color horizon;
        public Color night;
        public Color transparent;
        public Color sunColor;
        public float daycycle = 60;
        float updateDelay = .01f;
        public Material cloud1;
        public Material cloud2;
        public Material cloud3;
        public Material cloud4;
        public Material cloud5;

        void Start() {
            InvokeRepeating("TimeSecond", 0f, 1f);
            InvokeRepeating("UpdateLight", 0f, updateDelay);
        }

        void Awake()
        {
            sun = GetComponent<Light>();
            sun.transform.eulerAngles = new Vector3(90, 0, 0);
            sunDirId = Shader.PropertyToID("_SunDirection");
            sunColorId = Shader.PropertyToID("_SunColor");
        }

        void Update()
        {
            if (skyboxMaterial)
            {
                skyboxMaterial.SetVector(sunDirId, -transform.forward.normalized);
                skyboxMaterial.SetColor(sunColorId, sun.color);
            }
        }

        void TimeSecond() {
            timer++;
        }

        void UpdateLight()
        {
            float daytime = timer%daycycle < daycycle/2 ? timer%daycycle : (daycycle - timer%daycycle);
            skyboxMaterial.SetColor("_AmbientSky", Color.Lerp(sky, night, daytime/(daycycle/2)));
            skyboxMaterial.SetColor("_AmbientHorizon", Color.Lerp(horizon, night, daytime/(daycycle/2)));
            cloud1.SetColor("_Color", Color.Lerp(Color.white, transparent, daytime/(daycycle/3)));
            cloud2.SetColor("_Color", Color.Lerp(Color.white, transparent, daytime/(daycycle/3)));
            cloud3.SetColor("_Color", Color.Lerp(Color.white, transparent, daytime/(daycycle/3)));
            cloud4.SetColor("_Color", Color.Lerp(Color.white, transparent, daytime/(daycycle/3)));
            cloud5.SetColor("_Color", Color.Lerp(Color.white, transparent, daytime/(daycycle/3)));
            sun.GetComponent<Light>().color = Color.Lerp(sunColor, Color.black, daytime/(daycycle/2));
            sun.transform.Rotate(360/daycycle*updateDelay, 0, 0);
        }
    }
}