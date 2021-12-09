using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnackRandomizer : MonoBehaviour
{

    public Sprite[] images;
    public Sprite snackImage;
    public GameObject Image;

    void Start()
    {
    randomizeImage();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        randomizeImage();
        }
    }

    // Update is called once per frame
    void randomizeImage()
    {
     int random = Random.Range(0, images.Length);
     snackImage = images[random];
     Image.GetComponent<Image>().sprite = snackImage;
    }
}
