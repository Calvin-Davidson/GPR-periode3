using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeWithEase : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 eindPosition;
    [SerializeField] private EasingType _easingType;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveAtSpeedCoroutine(eindPosition, speed, _easingType));
            StartCoroutine(EaseScale(new Vector3(4,4,4), speed, _easingType));
        }
    }

    public IEnumerator MoveAtSpeedCoroutine(Vector3 goal, float speed, EasingType type)
    {
        Vector3 startPos = transform.position;
        
        for (float i = 0; i < 1; i += speed / 100)
        {
            transform.position = Vector3.LerpUnclamped(startPos, goal, Easing.Ease(type, i));
            yield return null;
        }
        
        this.transform.position = goal;
    }
    
    public IEnumerator EaseScale(Vector3 targetScale, float speed, EasingType type)
    {
        Vector3 startPos = transform.localScale;
        
        for (float i = 0; i < 1; i += speed / 100)
        {
            Vector3 v = Vector3.LerpUnclamped(startPos, targetScale, Easing.Ease(type, i));
            transform.localScale = v;
            yield return null;
        }
        
        this.transform.localScale = targetScale;
    }
    
}