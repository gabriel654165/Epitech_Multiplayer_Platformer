using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    [Header("Moving2")]
    public float movingOffsetRigth = 4f;
    public float movingOffsetLeft = -4f;
    public Vector3 velocity = new Vector3(5, 0, 0);

    
    private bool movingRigth = false;
    private bool movingLeft = true;
    
    
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