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
     * Met � jour le meilleur score enregistr�
     * 
     * Entr�e : String name : Le nom du meilleur score
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
     * V�rifie si le meilleur score est battue,
     * Renvoie la r�poonse sour forme de boolean.
     * 
     * Entr�e : Null
     * 
     * Sortie : bool rep : la r�ponse � la v�rification du meilleur score battue
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
     * Reinitialise les variable n�cessaire
     * 
     * Entr�e : Null
     * 
     * Sortie : Null
     */

    public void RestartGame()
    {
        currentScore = 0;
    }



}
