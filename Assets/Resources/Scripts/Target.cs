﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
//[RequireComponent (typeof(BoxCollider2D))]
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
        if (gameObject.tag == "Ally") {
            UI.gameover = true;

        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1 && !UI.gameover)
            UI.victory = true;
        yield return new WaitForSeconds(1.5f);
        if (gameObject.tag == "Ally") {
            SceneManager.LoadScene("game_over");
          //  UI.Reset();
        }
        Destroy(gameObject);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1 && !UI.gameover) {
            Debug.Log(SceneManager.GetActiveScene());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
       /* if(victory)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/
    }
}
