using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Win;
    public Game Game;
    //public AudioSource FinishSound;

    void Start()
    {
        //FinishSound = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if (!collision.collider.TryGetComponent(out Game game)) return;

       // Game.OnPlayerWon();
        //FinishSound.Play();
        Win.SetActive(true);
    }


}
