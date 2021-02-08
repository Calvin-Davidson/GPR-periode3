using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 eindPosition;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveAtSpeedCoroutine(eindPosition, speed));
        }
    }

    public IEnumerator MoveAtSpeedCoroutine(Vector3 goal, float speed){

        while (Vector3.Distance(this.transform.position,goal)>speed*Time.deltaTime){
            this.transform.position = Vector3.MoveTowards(this.transform.position, goal, speed*Time.deltaTime);
            yield return null;
        }
        this.transform.position = goal;
    }
}