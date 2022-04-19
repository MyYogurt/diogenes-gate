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

    void Start()
    {
        Anima = GetComponent<Animator>();
        state = 0;
        GameController curr = GameController.getInstance();
        transform.position = curr.worldDetails.lastPosition;
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
    }
}
