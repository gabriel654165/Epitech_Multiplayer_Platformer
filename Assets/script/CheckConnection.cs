using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CheckConnection : NetworkBehaviour
{
    void Update() {
        if (!isLocalPlayer)
            Debug.Log("server");
        else if (isLocalPlayer)
            Debug.Log("client");
    }
}
