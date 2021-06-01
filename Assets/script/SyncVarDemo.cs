using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SyncVarDemo : NetworkBehaviour
{
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

    [SyncVar(hook = nameof(SetColor))]
    private Color32 color = Color.red;

    public override void OnStartServer()
    {
        base.OnStartServer();
        StartCoroutine(__RandomizeColor());
    }

    private void SetColor(Color32 oldColor, Color32 newColor)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = newColor;
    }

    private IEnumerator __RandomizeColor()
    {
        WaitForSeconds wait = new WaitForSeconds(2f);

        while (true) {
            yield return wait;
            color = Random.ColorHSV(0f, 1f, 1f, 1f, 0f, 1f, 1f, 1f);
            // color = Color.blue;
        }
    }
}
