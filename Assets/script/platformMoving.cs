using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class platformMoving : MonoBehaviour
{
    [Header("Moving")]
    public float movingOffsetRigth = 2f;
    public float movingOffsetLeft = -4f;
    public Vector3 velocity = new Vector3(3, 0, 0);
    
    private bool movingRigth = true;
    private bool movingLeft = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= movingOffsetRigth) {
            movingRigth = false;
            movingLeft = true;
        } else if (transform.position.x <= movingOffsetLeft) {
            movingLeft = false;
            movingRigth = true;
        }

        if (movingRigth) {
            transform.position += (velocity * Time.deltaTime);
        }
        if (movingLeft) {
            transform.position -= (velocity * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        collision.collider.transform.SetParent(null);
    }
}
