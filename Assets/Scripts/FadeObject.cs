using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    private Renderer _renderer;
    [SerializeField] private float fadeDelay;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer == null) enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_renderer.material.color.a <= 0)
            {
                StartCoroutine(Fade(1, 50));
            }
            else
            {
                StartCoroutine(Fade(0, 50));   
            }
        }
    }

    IEnumerator Fade(float alphaValue, float loopCount)
    {
        Material material = _renderer.material;
        float increment = (1 / loopCount);
        for (float t = 0.0f; t < 1.0f; t += increment)
        {
            Color color = material.color;
            color.a = Mathf.Lerp(color.a, alphaValue, t);
            material.color = color;
            _renderer.material = material;
            
            yield return new WaitForSeconds(fadeDelay / loopCount);
        }

        Color c = material.color;
        c.a = alphaValue;
        material.color = c;
        Debug.Log("DONE");
    }
}