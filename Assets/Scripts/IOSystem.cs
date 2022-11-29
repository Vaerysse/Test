using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IOSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* 
     * Charge le meilleur score enregistr� � ce jour.
     * Cr�e un fichier de sauvegarde vierge si pas de fichier de score pr�sent.
     * 
     * Entr�e : Null
     * 
     * Sortie : List<string> listScore : contient un nom et un score
     */

    public int LoadBestScore()
    {
        int score = 0;

        // On essaye d'ouvrire le fichier de score.
        try
        {
            StreamReader reader = new StreamReader(Application.dataPath + "/data/score.csv");

            bool endOfFile = false;
            while (!endOfFile)
            {
                string data_string = reader.ReadLine();
                if (data_string == null)
                {
                    endOfFile = true;
                    break;
                }
                else
                {
                    score = int.Parse(data_string);
                }
            }

            return score;
        }
        catch // Sinon on en cr�e un vierge et retourn le fichier cr�er
        {
            try
            {
                StreamWriter writer = new StreamWriter(Application.dataPath + "/data/score.csv");
                writer.WriteLine("0");
                writer.Close();
            }
            catch
            {
                Debug.Log("Probl�me lors de la cr�ation du fichier score!");
            }

            return score;
        }

    }

    /*
     * Permet de sauvegarder le score dans un fichier.
     * 
     * Entr�e : List<string> listScore : le nom et score � sauvegarder
     * 
     * Sortie : Null
     */
    public void SaveBestScore(int score)
    {
        // On sauvegarde le score dans un fichier.
        try
        {
            StreamWriter writer = new StreamWriter(Application.dataPath + "/data/score.csv");
            writer.WriteLine("" + score);
            writer.Close();
        }
        catch
        {
            Debug.Log("Probl�me lors de la sauvegarde du fichier score!");
        }

    }

}
