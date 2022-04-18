using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeMap : MonoBehaviour
{
    // Start is called before the first frame update

    int trigger=1;
    void OnTriggerEnter2D(Collider2D col)
    {
        trigger = 0;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        trigger = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //scenes?
        if (trigger==0 && Input.GetKey(KeyCode.Return))
        {

        }
        else if(Input.GetKey(KeyCode.Return))
        {
            GameObject originalGameObject = GameObject.Find("PlayerAvatar");
            GameController curr = GameController.getInstance();
            curr.worldDetails.lastPosition = originalGameObject.transform.position;
            curr.worldDetails.lastScene = curr.worldDetails.currentScene;
            curr.worldDetails.currentScene = 1;
            SceneManager.LoadScene(curr.worldDetails.currentScene);
        }
    }
}
