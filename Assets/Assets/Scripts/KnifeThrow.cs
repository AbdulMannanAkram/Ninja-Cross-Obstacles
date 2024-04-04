using System.Collections;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    public GameObject knifePrefab;
    public float throwForce = 10f;
    public float rotationSpeed = 10f;
    public Transform playerTransform;
    public GameObject playerRotator;

    void Update()
    {
            if(Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 instantiatePosition = playerTransform.position;
            instantiatePosition.x += 1;
            GameObject knife = Instantiate(knifePrefab, instantiatePosition, Quaternion.identity);
            knife.GetComponent<Rigidbody2D>().AddForce(Vector2.right * throwForce, ForceMode2D.Impulse);
            knife.GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
           //adding 360 rotation to 
           //playerTransform.rotation.AddForce
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}

