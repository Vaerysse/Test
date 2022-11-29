using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTitleMenu : MonoBehaviour
{
    public Text textBestScore;

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
     * Entrée : List<string> bestScore : une liste contenant le nom et le score du meilleur score
     * 
     * Sortie : Null
     */
    public void MAJOverviewBestScore(List<string> bestScore)
    {
        Debug.Log(bestScore[0]);
        Debug.Log(int.Parse(bestScore[1]));
        textBestScore.text = "Meilleur score : \n" + bestScore[0] + " : " + bestScore[1];
    }
}
