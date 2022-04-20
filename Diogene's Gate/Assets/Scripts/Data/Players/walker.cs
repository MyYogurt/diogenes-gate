using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class walker : MonoBehaviour
{
    // Start is called before the first frame update
    Animator Anima;
    float speed;
    float accel;
    int state;

    // Data for enemy encounters
    public LayerMask enemyLayer;
    public int encounterCounter;

    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene ();
 
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        Anima = GetComponent<Animator>();
        state = 0;
        GameController curr = GameController.getInstance();
        transform.position = curr.worldDetails.lastPosition;
        if(sceneName == "town")
        {
            transform.position = new Vector3(390, -36, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) && (state==1||state==0))
        {
            Anima.SetBool("w", true);
            transform.Translate(0, .06f, 0);
            state = 1;
        }
        else if (Input.GetKey(KeyCode.A) && (state == 2 || state == 0))
        {
            Anima.SetBool("a", true);
            transform.Translate(-.06f, 0, 0);
            state = 2;
        }
        else if (Input.GetKey(KeyCode.S) && (state == 3 || state == 0))
        {
            Anima.SetBool("s", true);
            transform.Translate(0, -.06f, 0);
            state = 3;
        }
        else if (Input.GetKey(KeyCode.D) && (state == 4 || state == 0))
        {
            Anima.SetBool("d", true);
            transform.Translate(.06f, 0, 0);
            state = 4;
        }
        else
        {
            Anima.SetBool("w", false);
            Anima.SetBool("a", false);
            Anima.SetBool("s", false);
            Anima.SetBool("d", false);
            state = 0;
        }

        CheckForEncounters();
    }

    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, enemyLayer) != null)
        {
            if(Random.Range(1, 801) <= 10)
            {
                encounterCounter = encounterCounter + 1;
                if(encounterCounter >= 4)
                {
                    Debug.Log("Encountered an enemy, beging battle phase");
                    encounterCounter = 0;
                }
            }
        }
    }
}
