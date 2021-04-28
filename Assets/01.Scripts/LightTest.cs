using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTest : MonoBehaviour
{
    Light2D myLight;

    float timer = 0.5f;
    void Start()
    {
        myLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //myLight.color = Random.ColorHSV();

        timer -= Time.deltaTime;

        if(timer > 0)
        {
            myLight.pointLightOuterRadius = Mathf.Lerp(myLight.pointLightOuterRadius, 10f, Time.deltaTime);
        }
    }
}
