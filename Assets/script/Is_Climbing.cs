using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_Climbing : MonoBehaviour
{
    GameObject tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "wallrun") {
            tmp.GetComponent<player>().isClimbing = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "wallrun")
            tmp.GetComponent<player>().isClimbing = false;
    }
}
