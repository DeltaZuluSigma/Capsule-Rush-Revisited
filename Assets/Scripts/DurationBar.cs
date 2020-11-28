using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode()]
public class DurationBar : MonoBehaviour
{
    public int max;
    public int current;
    public Image mask;
    //private float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        max = 100;
        current = 0;
        //elapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(current > 0) { current -= 1; }
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)max;
        mask.fillAmount = fillAmount;
    }
}
