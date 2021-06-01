using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class isFreeze : MonoBehaviour
{
    [Header("Component")]
    public GameObject god;

    [Header("Freeze")]
    private float time;
    public bool freeze;
    void Start()
    {
        time = 0;
        freeze = false;
    }

    void Update()
    {
        if (freeze) {
            GetComponent<player>().moveSpeed = 0f;
            time += Time.deltaTime;
            if (time >= 4)
                freeze = false;
        }
        else {
            time = 0;
            GetComponent<player>().moveSpeed = 5f;
        }
    }
}

