using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    private Rigidbody2D rb;
    float tempNumber;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.velocity=new Vector2(GameController.instance.scrollSpeed,0);
        tempNumber=GameController.instance.scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // if(GameController.instance.gameOverBool==true)
        // {
        //     rb.velocity=Vector2.zero;
        // }
        // if(GameController.instance.scrollSpeed<tempNumber)
        // {
        //  rb.velocity=new Vector2(GameController.instance.scrollSpeed,0);   
        //  tempNumber=GameController.instance.scrollSpeed;
        // }


    }

}
