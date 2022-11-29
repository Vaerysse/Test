using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IOSystem : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        LoadBestScore();
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
     * Sortie : Null
     */

    public void LoadBestScore()
    {
        List<string> listScore = new List<string>();

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
                    var dataline = data_string.Split(";");
                    foreach (string data in dataline)
                    {
                        listScore.Add(data);
                    }
                }
            }

            //TODO : gestion de la r�cup�ration des donn�e une fois la gestion du score en place

        }
        catch // Sinon on en cr�e un vierge.
        {
            try
            {
                StreamWriter writer = new StreamWriter(Application.dataPath + "/data/score.csv");
                writer.WriteLine("Unknow;0");
                writer.Close();
            }
            catch
            {
                Debug.Log("Probl�me lors de la cr�ation du fichier score!");
            }
        }

    }

    /*
     * Permet de sauvegarder le score dans un fichier.
     * 
     * Entr�e : Null
     * 
     * Sortie : Null
     */
    public void SaveBestScore()
    {
        // On sauvegarde le score dans un fichier.
        try
        {
            StreamWriter writer = new StreamWriter(Application.dataPath + "/data/score.csv");
            writer.WriteLine(" ");
            //TODO : gestion de la save lorsque gestion de score mis en place ok
            writer.Close();
        }
        catch
        {
            Debug.Log("Probl�me lors de la cr�ation du fichier score!");
        }

    }

    /*
    // Met � jour la matrice utilisateur pr�sent dans le syst�me
    public void saveData(List<GameObject> listFear)
    {
        string name = "";
        string int1 = "";
        string int2 = "";
        string int3 = "";
        string fail = "";
        string win = "";
        int cpt = 1;


        foreach (GameObject go_f in listFear)
        {
            name = name + go_f.GetComponent<FearSystem>().getFearName();
            int1 = int1 + go_f.GetComponent<FearSystem>().getIntensity()[0];
            int2 = int2 + go_f.GetComponent<FearSystem>().getIntensity()[1];
            int3 = int3 + go_f.GetComponent<FearSystem>().getIntensity()[2];
            fail = fail + go_f.GetComponent<FearSystem>().getFail();
            win = win + go_f.GetComponent<FearSystem>().getWin();

            if (cpt != listFear.Count)
            {
                name = name + ";";
                int1 = int1 + ";";
                int2 = int2 + ";";
                int3 = int3 + ";";
                fail = fail + ";";
                win = win + ";";
            }
            cpt++;

        }

        try
        {
            StreamWriter writer = new StreamWriter(Application.dataPath + "/User/LearnerModel" + nbModel + ".csv");
            //StreamWriter writer = new StreamWriter("E:/Unity_project/evhi_modele/Assets/User/LearnerModel" + nbModel + ".csv");

            writer.WriteLine(name);
            writer.WriteLine(int1);
            writer.WriteLine(int2);
            writer.WriteLine(int3);
            writer.WriteLine(fail);
            writer.WriteLine(win);

            writer.Close();

        }
        catch
        {
            Debug.Log("Probl�me lors de la sauvegarde du model!");
        }
    }
    */
}
