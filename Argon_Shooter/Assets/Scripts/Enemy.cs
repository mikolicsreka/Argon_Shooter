using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int scorePerHit = 12;

    [SerializeField] int maxHits = 10;

    ScoreBoard scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        maxHits--;

        if (maxHits < 1)
        {
            KillEnemy();
        }
        

    }

    private void KillEnemy()
    {

        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); //létrehozni
        fx.transform.parent = parent;
        print("particles works");


        Destroy(gameObject); //gameObjecttel hivatkozunk azokra akiken rajta van a script 
    }
}
