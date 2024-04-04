using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsPooling : MonoBehaviour
{
    public int columnSize=5;
    public GameObject[] columnPrefab;
    private GameObject[] columns;
    private Vector2 objectPoolPosition=new Vector2(-15f,-25f);
    public float spawnRate=4f;
    private float timeSinceLastSpawned;
    public float columnMin=-1f;
    public float columnMax=3.5f;
    private float spawnXPosition=10f;
    private int currentColumn=0;
    // Start is called before the first frame update
    void Start()
    {
      //  columnPrefab=new GameObject[3];
        columns=new GameObject[columnSize];
        for(int i=0;i<columnSize;i++)
        {
            int randomNumber=Random.Range(0,2);
            columns[i]=(GameObject)Instantiate(columnPrefab[randomNumber],objectPoolPosition,Quaternion.identity);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned+=Time.deltaTime;
        if(GameController.instance.gameOverBool==false&& timeSinceLastSpawned>=spawnRate)
        {
            timeSinceLastSpawned=0;
            float spawnYPosition=Random.Range(columnMin,columnMax);
            columns[currentColumn].transform.position=new Vector2(spawnXPosition,spawnYPosition);
            columns[currentColumn].transform.GetChild(2).gameObject.SetActive(true);
            columns[currentColumn].transform.GetChild(3).gameObject.SetActive(true);
            columns[currentColumn].transform.GetChild(4).gameObject.SetActive(true);

            currentColumn++;
            if(currentColumn>=columnSize)
            {
                currentColumn=0;
            }
        }
    }
}
