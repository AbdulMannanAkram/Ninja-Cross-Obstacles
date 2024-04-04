using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float upForce=200f;
    private bool isDead=false;
    private Rigidbody2D rb;
    private Transform birdPosition;
    public int health = 100;
    public float rotationSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        birdPosition = rb.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Space key is pressed");
        //    StartCoroutine(RotateObject());
        //}
        if (isDead==false)
        {
            if(Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))
            {
            rb.velocity=Vector2.zero;
            rb.AddForce(new Vector2(0f,upForce));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Enemy")
        {
        }

        else if (GameController.instance.LiveCheck())
        {
            GameController.instance.BirdDied();
            GameController.instance.RestartButton();

        }
        else
        {
            isDead = true;
            GameController.instance.BirdDied();
        }
    }
    public void DecreaseHealth(int amount)
    {
        this.health -= amount;
        Debug.Log("player health is : " + health);
        if (health <= 0)
        {
            // Player is dead
            Debug.Log("Player is dead!");
            if (GameController.instance.LiveCheck())
            {
                GameController.instance.BirdDied();
                GameController.instance.RestartButton();

            }
            else
            {
                isDead = true;
                GameController.instance.BirdDied();
            }
        }
    }


    IEnumerator RotateObject()
    {
        float rotationAmount = 0f;
        while (rotationAmount < 360f)
        {
            rotationAmount += Time.deltaTime * rotationSpeed;
            this.transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
            yield return null;
        }
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}