using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderScript : MonoBehaviour
{
    public Slider progressSlider;
    public float curProgress;
    public float newProgress;
    public float fillSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progressSlider.value = curProgress;
        fillSpeed = Time.deltaTime * 0.15f;
        curProgress = Mathf.MoveTowards(curProgress, newProgress, fillSpeed);
    }
}
