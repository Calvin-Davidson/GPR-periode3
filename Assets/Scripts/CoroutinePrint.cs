using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinePrint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Ik start nu de coroutine", 0.5);
        StartCoroutine("Coroutine update", 1);
        StartCoroutine("Coroutine einde", 1.5);
    }

    public IEnumerator print(String msg, float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log(msg);
    }
}
