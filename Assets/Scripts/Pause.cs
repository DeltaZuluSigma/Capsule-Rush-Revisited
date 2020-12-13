using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool paused;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pausing()
    {
        if (paused)
        {
            button.SetActive(false);
            paused = false;
        }
        else
        {
            button.SetActive(true);
            paused = true;
        }
    }
}
