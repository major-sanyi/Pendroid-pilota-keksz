﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent (typeof(BoxCollider2D))]
public class Target : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball") {
            GetComponent<ParticleSystem>().Play();
            StartCoroutine(Example(gameObject));
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.Explosion);
        }  
    }
    IEnumerator Example(GameObject gameObject)
    {
        yield return new WaitForSeconds(1.5f);
        if (gameObject.name == "DONT HIT HIM")
            SceneManager.LoadScene("game_over");
        Destroy(gameObject);
    }
}
