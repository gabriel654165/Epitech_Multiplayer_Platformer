using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOfFriendship : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collider)  {
        if (collider.transform.root.gameObject.tag == "Player"
            && collider.transform.root.gameObject.GetComponent<isFreeze>().freeze) {

        }
    }
}
