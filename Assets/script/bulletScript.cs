using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 20;
    public float distance = 10f;
    private float beg = 0f;
    public SpriteRenderer renderer;

    public void init(int i)
    {
        if (i == 0) {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        if (i == 1) {
            GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
        }
    }

    
    private void OnCollisionEnter2D(Collision2D hit) {
        if (hit.gameObject.tag == "Player") {
            if (GetComponent<SpriteRenderer>().color == Color.green) {
                hit.gameObject.GetComponent<player>().jumpHigh = true;
            }
            if (GetComponent<SpriteRenderer>().color == Color.red) {
                hit.gameObject.GetComponent<player>().runFast = true;                
            }
        }
        Destroy(gameObject);
    }

    public void setColor(Color color) {
        GetComponent<SpriteRenderer>().color = color;
    }
}
