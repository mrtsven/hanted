using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public float sec;
    public Light light;

    private void Start()
    {
        StartCoroutine("LightOn", sec);
    }

    IEnumerator LightOn(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            if (light.enabled)
            {
                light.enabled = false;
                GetComponent<SphereCollider>().enabled = true;
            }
            else
            {
                light.enabled = true;
                GetComponent<SphereCollider>().enabled = false;
            }
        }
    }


}