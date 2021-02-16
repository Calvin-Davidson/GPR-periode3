using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeWithEase : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 eindPosition;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveAtSpeedCoroutine(eindPosition, speed));
            StartCoroutine(EaseScale(new Vector3(4,4,4), speed));
        }
    }

    public IEnumerator MoveAtSpeedCoroutine(Vector3 goal, float speed)
    {
        Vector3 startPos = transform.position;
        
        for (float i = 0; i < 1; i += speed / 100)
        {
            transform.position = Vector3.LerpUnclamped(startPos, goal, Easing.EaseInBack(i));
            yield return null;
        }
        
        this.transform.position = goal;
    }
    
    public IEnumerator EaseScale(Vector3 targetScale, float speed)
    {
        Vector3 startPos = transform.localScale;
        
        for (float i = 0; i < 1; i += speed / 100)
        {
            Vector3 v = Vector3.LerpUnclamped(startPos, targetScale, Easing.EaseInBack(i));
            Debug.Log(v.ToString());
            transform.localScale = v;
            yield return null;
        }
        
        this.transform.localScale = targetScale;
    }
    
}