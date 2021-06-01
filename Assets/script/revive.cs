using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revive : MonoBehaviour
{
    private bool rev = false;
    public ParticleSystem system;
    private float time = 0;
    public GameObject player1;
    public GameObject player2;

    void Start() {
        system.Stop();
    }

    void Update()
    {
        if (rev) {
            time += Time.deltaTime;
            if (time >= 3) {
                rev = false;
                if (player1.GetComponent<player>().isInjured)
                    player1.GetComponent<player>().isInjured = false;
                if (player2.GetComponent<player>().isInjured)
                    player2.GetComponent<player>().isInjured = false;
                time = 0;
                system.Stop();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Player" && hit.gameObject.GetComponent<player>().isInjured) {
            rev = true;
            system.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D hit)
    {
        if (rev) {
            rev = false;
            time = 0;
            system.Stop();
        }
    }
}
