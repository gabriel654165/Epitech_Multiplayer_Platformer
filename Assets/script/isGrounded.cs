using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    GameObject play;
    // Start is called before the first frame update
    void Start()
    {
        play = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < play.GetComponent<player>().jumpCoolDown)
            play.GetComponent<player>().isGrounded = true;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "colide" || collision.collider.tag == "platform") {
            play.GetComponent<player>().isGrounded = true;
            play.GetComponent<player>().jumpCount = 0;
            play.GetComponent<player>().jumpCoolDown = Time.time + 0.2f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.tag == "colide" || collision.collider.tag == "platform")
            play.GetComponent<player>().isGrounded = false;
    }
}