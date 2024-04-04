using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // AM disable particle system
  //  public ParticleSystem particleSystemPrefab;

    public float rotationsPerMinute=10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationsPerMinute*Time.deltaTime,0);
    }
   private void OnTriggerEnter2D(Collider2D other) 
{
 if (other.GetComponent<BirdController>()!=null)
 {

            //this.transform.gameObject.SetActive(false);
                // AM disable particle system

           // ParticleSystem particleSystemInstance = Instantiate(particleSystemPrefab, this.transform.position, transform.rotation);
           // particleSystemInstance.Play();
            //Destroy(particleSystemInstance.gameObject, particleSystemInstance.main.duration);

           this.gameObject.SetActive(false);
            //     GameController.instance.PlayerScored();
        }    
}
}
