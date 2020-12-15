using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyButtonToContinue : MonoBehaviour
{
    public SceneChange sc;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKey)
        {
            sc.Change("MainMenu");
        }
    }
}
