using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private const float increment = 35.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        foreach(GameObject obj in levels)
        {
            loadChildObjects(obj);
        }
    }

    void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {
            reposChildObjs(obj);
        }
    }

    //Create duplicates
    void loadChildObjects(GameObject obj)
    {
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 1; i <= 2; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.localPosition = new Vector3(14.2f * i, 0f, 0f);
            c.name = obj.name + "(" + i + ")";
        }
        Destroy(clone);
    }

    //Reposition duplicates
    void reposChildObjs(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        GameObject first = children[1].gameObject;
        GameObject last = children[2].gameObject;
        if(transform.position.x >= last.transform.position.x + 20.0f)
        {
            first.transform.SetAsLastSibling();
            first.transform.position = new Vector3(last.transform.position.x + increment, 
                last.transform.position.y, last.transform.position.z);
        }
        else if(transform.position.x <= first.transform.position.x + 16.0f)
        {
            last.transform.SetAsFirstSibling();
            last.transform.position = new Vector3(first.transform.position.x - increment, 
                first.transform.position.y, first.transform.position.z);
        }
    }
}
