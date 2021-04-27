using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovment : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        target = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position =  Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x, transform.position.y) , 2 * Time.deltaTime);
    }
}
