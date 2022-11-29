using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionScore : MonoBehaviour
{
    public int bestScore;
    public int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        bestScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Met à jour le meilleur score enregistré
     * 
     * Entrée : int score : le meilleur score
     *          
     * Sortie : Null
     */
    public void MAJBestScore(int score)
    {
        bestScore = score;
    }

    /*
     * Vérifie si le meilleur score est battue,
     * Renvoie la répoonse sour forme de boolean.
     * 
     * Entrée : Null
     * 
     * Sortie : bool rep : la réponse à la vérification du meilleur score battue
     * 
     */
    public bool TcheckIfBestNewBest()
    {
        bool newBestScore = false;
        if(currentScore >= bestScore)
        {
            newBestScore = true;
        }

        return newBestScore;
    }

    /*
     * Reinitialise les variable nécessaire
     * 
     * Entrée : Null
     * 
     * Sortie : Null
     */

    public void RestartGame()
    {
        currentScore = 0;
    }



}
