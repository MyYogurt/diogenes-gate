using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLoads : MonoBehaviour
{

    public LayerMask enemyLayer;
    public LayerMask load_Main;
    public LayerMask load_CrystalCaverns;
    public LayerMask load_EnchantedForest;
    public int encounterCounter;

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;


    // Start is called before the first frame update
    void Start()
    {
        // do nothing
    }

    // Update is called once per frame
    void Update()
    {
        CheckForNewLoad();
    }

    private void CheckForNewLoad()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, load_Main) != null)
        {  
            SceneManager.LoadScene("Main");
        }
        if(Physics2D.OverlapCircle(transform.position, 0.2f, load_CrystalCaverns) != null)
        {  
            SceneManager.LoadScene("Crystal_Caverns");
        }
        if(Physics2D.OverlapCircle(transform.position, 0.2f, load_EnchantedForest) != null)
        {  
            SceneManager.LoadScene("Enchanted_Forest");
        }
    }
}
