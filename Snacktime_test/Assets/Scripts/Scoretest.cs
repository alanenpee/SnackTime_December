using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Scoretest : MonoBehaviour
{
    public Slider progressSlider;
    public float curProgress;
    public float newProgress;
    public float fillSpeed = 5f;
    private SnackRandomizer snack;

    private void Start()
    {
        curProgress = 0f;
        snack = GetComponent<SnackRandomizer>();
    }


    void Update()
    {
     progressSlider.value = curProgress;
     fillSpeed = Time.deltaTime * 0.15f;
     curProgress = Mathf.MoveTowards(curProgress, newProgress, fillSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == snack.chosenSnack.tagName)
        {
            Debug.Log("Hit");
            newProgress += snack.chosenSnack.score / 100f;
        }
    }

}
