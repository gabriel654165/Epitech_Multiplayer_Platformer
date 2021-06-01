using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class playerColor : NetworkBehaviour
{
    [SyncVar(hook = nameof(ChangeColor))]
    Color pColor = Color.white;

    public void setColor(Color color) {
        pColor = color;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        pColor = Color.white;
    }

    void ChangeColor(Color oldColor, Color newColor) {
            GetComponent<SpriteRenderer>().color = newColor;
    }
}