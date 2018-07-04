using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundCollision : MonoBehaviour
{

    public AudioSource coinSound;
    public AudioSource goldCoinSound;
    public AudioSource collisionSound;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Tuerca")
        {
            coinSound.Play();
        }
        if (other.gameObject.tag == "TornilloDorado")
        {
            goldCoinSound.Play();
        }
        if(other.gameObject.tag == "Valla")
        {
            collisionSound.Play();
        }

    }
}
