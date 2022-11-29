using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionScore : MonoBehaviour
{
    public List<string> bestScore;
    public int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        bestScore = new List<string> { "Nothing", "0" };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Met à jour le meilleur score enregistré
     * 
     * Entrée : String name : Le nom du meilleur score
     *          int score : le meilleur score
     *          
     * Sortie : Null
     */
    public void MAJBestScore(string name, int score)
    {
        bestScore[0] = name;
        bestScore[1] = "" + score;
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
        if(currentScore >= int.Parse(bestScore[1]))
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
