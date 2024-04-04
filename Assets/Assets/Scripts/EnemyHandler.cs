using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector3(79.6f, transform.position.y, 1.298f);
        speed = Random.Range(6, 10);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Enter bird");
        Debug.Log("Here up");
        if (other.gameObject.tag == "Player")
        {

            // Decrease player's health by a random amount
            int damage = Random.Range(30, 65);
            Debug.Log("Here collide");
            other.gameObject.GetComponent<BirdController>().DecreaseHealth(damage);
            Destroy(this.gameObject);
        }
        else

        //if (other.gameObject.tag == "Obstacle")
        

        {
            Debug.Log("Destroy itself");
            Destroy(this.gameObject);
        }

    }
    public int speed = 10;

    void Update()
    {

        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime *speed);
    }
}