using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{

    // Start is called before the first frame update
    // void Start()
    // {

    // }
    static DontDestroyAudio instance = null;
    void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
