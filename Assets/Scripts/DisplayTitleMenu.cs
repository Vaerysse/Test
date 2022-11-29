using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTitleMenu : MonoBehaviour
{
    public Text textBestScore;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Mise à jour de l'affichage du meilleur score
     * 
     * Entrée : Null
     * 
     * Sortie : Null
     */
    public void MAJOverviewBestScore()
    {
        // On va chercher le meilleur score que contien le gameManager
        int bestScore = gameManager.GetComponent<GestionScore>().bestScore;
        // On l'affiche
        textBestScore.text = "Meilleur score : \n" + bestScore;
    }
}
