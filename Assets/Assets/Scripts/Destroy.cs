using UnityEngine;

public class Destroy : MonoBehaviour
{
    // public GameObject objectToDestroy;

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
     
    }
}
