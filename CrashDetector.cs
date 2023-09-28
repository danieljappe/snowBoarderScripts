using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] ParticleSystem crashEffect;

    public ScoreCounter scoreCounter;

    private void Start(){
    GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
    if (gameManager != null)
    {
        scoreCounter = gameManager.scoreCounter;
    }
}

    void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Ground") {
        Debug.Log("Player collided with Ground");
        crashEffect.Play();
        Invoke("ReloadScene", 1f);

        if (scoreCounter != null) {
            Debug.Log("scoreCounter is not null");
            scoreCounter.ResetScore();
        } else {
            Debug.LogError("scoreCounter is null");
        }
    }
}

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
