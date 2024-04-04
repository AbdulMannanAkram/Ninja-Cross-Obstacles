using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;
//    private float rotationAmount = 0f;
    // private bool rotating = false;

    void Update()
    {
            if(Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("inside");
           // this.GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
                    StartCoroutine(RotateObject());

            // rotating = true;
        }

        //if (rotating)
        //{
        //    rotationAmount += Time.deltaTime * rotationSpeed;
        //    this.transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);

        //    if (rotationAmount >= 360f)
        //    {
        //        rotating = false;
        //        rotationAmount = 0f;
        //       this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //    }
        //}
    }
IEnumerator RotateObject()
    {
        float rotationAmount = 0f;
        Debug.Log("Inside routine");

        while (rotationAmount < 360f)
        {
            Debug.Log("Inside while");
            rotationAmount += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
            Debug.Log("inside position" + transform.rotation+ "rotation amount "+rotationAmount);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

}


//public float rotationSpeed = 50f;

//void Update()
//{
//    if (Input.GetKeyDown(KeyCode.Space))
//    {
//        StartCoroutine(RotateObject());
//    }
//}

//IEnumerator RotateObject()
//{
//    float rotationAmount = 0f;
//    Debug.Log("Inside routine");

//    while (rotationAmount < 360f)
//    {
//        Debug.Log("Inside while");
//        rotationAmount += Time.deltaTime * rotationSpeed;
//        transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
//        yield return null;
//    }
//    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
//}

