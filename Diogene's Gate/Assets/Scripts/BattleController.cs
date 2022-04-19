using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleController : MonoBehaviour
{
    public bool inBattleScene;
    public UnityEngine.UI.Text textbox;
    public List<GameObject> players;
    public List<GameObject> enemies;
    Animator animator;
    int enemyType;
    int currentTurn;
    List<string> charNames;
    string enemyName;
    List<string> enemyNames;
    List<string> attackPatterns;
    List<string> attackResults;
    System.Random rand;
    string battleText;
    int confirmedHitsOnEnemy;

    void StartBattle()
    {
        currentTurn = 0;
        enemyType = rand.Next(0, 3);
        animator.SetInteger("enemyType", enemyType);
        inBattleScene = true;
        enemyName = enemyNames[enemyType];
        GetComponent<SpriteRenderer>().enabled = true;
        textbox.enabled = true;
        battleText = enemyName + " appears!";
        textbox.text = battleText;
        confirmedHitsOnEnemy = 0;
    }

    void EndBattle()
    {
        inBattleScene = false;
        GetComponent<SpriteRenderer>().enabled = false;
        textbox.enabled = false;
    }

    string GetBattleText()
    {
        if (battleText.EndsWith("continue.")) {
            EndBattle();
            return "";
        }
        if (confirmedHitsOnEnemy >= 3) {
            return "The " + enemyName + "has been defeated! Press SPACE to continue.";
        }
        string attacker;
        string attack;
        string target;
        string result;
        if (currentTurn%2==0) {
            attacker = charNames[rand.Next(charNames.Count)];
            target = enemyName;
        } else {
            attacker = enemyName;
            target = charNames[rand.Next(charNames.Count)];
        }
        attack = attackPatterns[rand.Next(attackPatterns.Count)];
        result = attackResults[rand.Next(attackResults.Count)];
        currentTurn += 1;
        if (currentTurn % 2 == 0 && (result.EndsWith("it.") || result.EndsWith("damage!"))) {
            confirmedHitsOnEnemy++;
        }
        return attacker + attack + target + result;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        charNames = new List<string>();
        charNames.Add("McJRPG Guy");
        charNames.Add("Jojo Spell");
        charNames.Add("The Rogue");
        enemyNames = new List<string>();
        enemyNames.Add("Nebulous Segfault");
        enemyNames.Add("Eternal Runtime");
        enemyNames.Add("Stack Overflow");
        attackPatterns = new List<string>();
        attackPatterns.Add(" swings wildly at ");
        attackPatterns.Add(" casts a horrific spell which targets ");
        attackPatterns.Add(" creates an incomprehensible attack near ");
        attackResults = new List<string>();
        attackResults.Add(", but it misses!");
        attackResults.Add(" and damages it. ");
        attackResults.Add(", dealing massive damage!");
        rand = new System.Random();
        inBattleScene = false;
        GetComponent<SpriteRenderer>().enabled = false;
        textbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o") && !inBattleScene)
        {
            StartBattle();
            Debug.Log("now starting battle...\n");
        }
        if (Input.GetKeyDown("p"))
        {
            EndBattle();
            Debug.Log("now ending battle...");
        }
        if (rand.Next(0, 10000) <= 2 && !inBattleScene)
        {
            StartBattle();
        }
        if (inBattleScene)
        {
            if (Input.GetKeyDown("space")) {
                battleText = GetBattleText();
                textbox.text = battleText;
            }
        }
    }
}