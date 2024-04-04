using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("position of transform position is : "+transform.position.x);
        groundCollider=GetComponent<BoxCollider2D>();
        groundHorizontalLength=groundCollider.size.x;
        Debug.Log("position of ground length is : "+groundHorizontalLength);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<((groundHorizontalLength*2)+3))
        {
            RepositionBackGrond();
        }
        Debug.Log("position of transform position is : "+transform.position.x);
        Debug.Log("position of ground length is : "+(groundHorizontalLength*2+3));
    }
    private void RepositionBackGrond()
    {
        Vector2 groundOffset=new Vector2(groundHorizontalLength*2f,0);
        transform.position=(Vector2)transform.position+groundOffset;
    }
}