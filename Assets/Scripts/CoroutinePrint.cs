using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinePrint : MonoBehaviour
{

    void Start()
    {
        Dictionary<String, float> messagesToPrint = new Dictionary<string, float>();
        
        // Fill the map with the messages and there delays.
        messagesToPrint.Add("Ik start nu de coroutine", 0);
        for (int i = 0; i < 10; i++)
        {
            messagesToPrint.Add("coroutine update - " + i, 0.5f);
        }
        messagesToPrint.Add("coroutine einde", 0);
        
        
        StartCoroutine(PrintMessages(messagesToPrint));
    }

    public IEnumerator PrintMessages(Dictionary<String, float> map)
    {
        foreach (var keyValuePair in map)
        {
            String message = keyValuePair.Key;
            float delay = keyValuePair.Value;
            yield return new WaitForSeconds(delay);
            Debug.Log(message);
        }
    }
}
