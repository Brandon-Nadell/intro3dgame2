using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
    public class Starvation : MonoBehaviour
    {

        public float starvationCooldown;
        public Material skyboxMaterial;

        int timer = 0;
        public Damageable damageable;
        public Color sky;
        public Color horizon;
        public Color night;
        public float daycycle = 60;
        public Material moon;
        public Color transparent;
        public Material cloud1;
        public Material cloud2;
        public Material cloud3;
        public Material cloud4;
        public Material cloud5;
        public GameObject sun;
        public Color sunColor;
        float updateDelay = .01f;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("TimeSecond", 0f, 1f);
            InvokeRepeating("UpdateLight", 0f, updateDelay);
        }

        void TimeSecond() {
            timer++;
            if (timer % starvationCooldown == 0) {
                damageable.DecreaseHealth();
            }
        }

        void UpdateLight()
        {
            float daytime = timer%daycycle < daycycle/2 ? timer%daycycle : (daycycle - timer%daycycle);
            skyboxMaterial.SetColor("_AmbientSky", Color.Lerp(sky, night, daytime/(daycycle/2)));
            skyboxMaterial.SetColor("_AmbientHorizon", Color.Lerp(horizon, night, daytime/(daycycle/2)));
            moon.SetColor("_Color", Color.Lerp(transparent, Color.white, daytime/(daycycle/2)));
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
