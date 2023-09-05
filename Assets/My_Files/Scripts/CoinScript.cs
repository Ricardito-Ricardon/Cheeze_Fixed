using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioSource Ding;

    private void Start()
    {
        this.Ding.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreKeeper>().AddScore(1);
            Ding.Play();
            Destroy(this.gameObject); // To destroy
        }
    }
}
