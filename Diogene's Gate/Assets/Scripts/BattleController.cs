using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public bool inBattleScene;
    public List<GameObject> players;
    public List<GameObject> enemies;
    Animator animator;
    int enemyType;
    int turn;
    int subturn;
    List<string> charNames;


    void startBattle()
    {
        turn = 0;
        subTurn = 0;
        enemyType = Random.Range(0, 3);
        animator.SetInteger("enemyType", enemyType);
        inBattleScene = true;
    }

    void endBattle()
    {
        inBattleScene = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            startBattle();
            Debug.Log("now starting battle...\n");
        }
        if (Input.GetKeyDown("p"))
        {
            endBattle();
            Debug.Log("now ending battle...");
        }
        if (Random.Range((float)0.0, (float)1.0) < 0.001 && !inBattleScene)
        {
            startBattle();
        }
        if (inBattleScene)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        } else {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
