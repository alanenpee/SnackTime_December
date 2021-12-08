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
    public SliderScript slider;
    private SnackRandomizer snack;

    private void Start()
    {
        snack = GetComponent<SnackRandomizer>();
    }


    void Update()
    {
    
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == snack.chosenSnack.tagName)
        {
            Debug.Log("Hit");
            slider.newProgress += snack.chosenSnack.score / 100f;
        }
    }

}
