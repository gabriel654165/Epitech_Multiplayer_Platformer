using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isEnd : MonoBehaviour
{
    public player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "end") {
            //player.moveSpeed = 0f;
            player.rgb.gravityScale = 0;
            player.isEnd = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "end")
            //player.moveSpeed = 5f;
            player.isEnd = true;
    }
}

