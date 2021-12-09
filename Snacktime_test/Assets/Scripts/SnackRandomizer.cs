using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

public class SnackRandomizer : MonoBehaviour

{
    [System.Serializable]
    public class SnackPair 
    {
        public Sprite image;
        public string tagName;
        public int score;

    }

    public SnackPair[] images;
    public SnackPair chosenSnack;
    public GameObject Image;

    public static SnackRandomizer instance;

    void Awake()
    {
     instance = this;
     randomImage();
    }

    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            randomImage();
        }
    }

    void randomImage()
    {
        int random = Random.Range(0, images.Length);
        chosenSnack = images[random];
        Image.GetComponent<Image>().sprite = chosenSnack.image;
        
    }


}



