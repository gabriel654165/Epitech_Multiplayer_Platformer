using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Components")]
    public player player;

    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float alltime = 250;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0,0));
    }
    // public GameObject objectToFollow;
    
    // public float speed = 2.0f;
    
    // void Update () {
    //     float interpolation = speed * Time.deltaTime;
        
    //     Vector3 position = this.transform.position;
    //     position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
    //     position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
        
    //     this.transform.position = position;
    // }
}
