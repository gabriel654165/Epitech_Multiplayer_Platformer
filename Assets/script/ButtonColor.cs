using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class ButtonColor : NetworkBehaviour
{
    public Button yourButton;

    [SyncVar]
    public GameObject Player;

    void Start () {
        yourButton.onClick.AddListener(TaskOnClick);
	}

    void Update () {
        if (isLocalPlayer)
            Debug.Log("CLIENT");

    }

	void TaskOnClick()
    {
        if (isLocalPlayer) {
            Debug.Log("JE CLIQUE SUR UN BOUTON");
            ChangeColor();
        }
	}
    void ChangeColor() {
        if (!isServer) return;
        Player.GetComponent<playerColor>().setColor(yourButton.colors.normalColor);
    }
}

/*
  	public Button yourButton;
    [SyncVar] public GameObject Player;
    [SyncVar] public Material nMaterial;
	void Start () {
		yourButton.onClick.AddListener(TaskOnClick);
	}

    [ClientRpc]
	void TaskOnClick(){
        Player.GetComponent<SpriteRenderer>().material = nMaterial;
	}
*/