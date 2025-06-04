using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flashing : MonoBehaviour
{
    Light light;
    float minSpeed = 0.3f;
    float maxSpeed = 0.8f;
    float minInt = 1f;
    float maxInt = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(run());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator run(){
        while(true){
            light.enabled = true;
            light.intensity = Random.Range(minInt, maxInt);
            yield return new WaitForSeconds(Random.Range(minSpeed, maxSpeed));
            light.enabled = false;
            yield return new WaitForSeconds(Random.Range(minSpeed, maxSpeed));
        }
    }
}
