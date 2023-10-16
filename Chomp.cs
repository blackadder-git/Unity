using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomp : MonoBehaviour
{
    public AudioSource chomp;

    public void OnTriggerEnter(Collider other) {
        print(other.gameObject.name + " has eaten object");

        // https://www.youtube.com/watch?v=VomZe-_WWsE
        chomp.Play();
    }
}
