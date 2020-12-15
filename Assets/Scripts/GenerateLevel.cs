using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] blockPrefabs = new GameObject[8];
    public GameObject StartBlock;
    public GameObject EndBlock;
    
    private GameObject lastBlock;
    private Vector3 nextStop;
    private GameObject  newBlock;
    private Vector3 insPos;

    // Start is called before the first frame update
    void Start()
    {
        newBlock = Instantiate(StartBlock, new Vector3(0, 0, 0), Quaternion.identity);
        lastBlock = newBlock;
        for (int i = 0; i < 10; i++)
        {
            CreateNewBlock();
        }
        insPos = lastBlock.transform.Find("End").transform.position;
        newBlock = Instantiate(EndBlock, insPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update ()
    {
        RollCamera();
    }

    void RollCamera(){
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * 0.2f);
    }

    void CreateNewBlock(){
        int index = (int) Mathf.Floor(Random.Range(0,8));
        insPos = lastBlock.transform.Find("End").transform.position;
        newBlock = Instantiate(blockPrefabs[index], insPos, Quaternion.identity);
        lastBlock = newBlock;
    }
}
