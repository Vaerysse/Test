using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public GameObject displayManager;

    // Start is called before the first frame update
    void Start()
    {
        InitializeBestScore();
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Charge le meilleur score enregistré dans le systéme et l'affiche
     * 
     * Entrée : Null
     * 
     * Sortie : Null
     */
    void InitializeBestScore()
    {
        // Charge le meilleur score
        List<string> bestScoreTemp = GetComponentInParent<IOSystem>().LoadBestScore();
        GetComponentInParent<GestionScore>().MAJBestScore(bestScoreTemp[0], int.Parse(bestScoreTemp[1]));
        // Affiche le meilleur score chargé
        if(displayManager != null)
        {
            displayManager.GetComponent<DisplayTitleMenu>().MAJOverviewBestScore(bestScoreTemp);
        }
    }
}
