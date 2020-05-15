using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
       int numMusicPlayer =  FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

       
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnParticleCollision(GameObject other)
    {
        print("Particles collided with enemy: " + gameObject.name);
    }
    // Update is called once per frame

}
