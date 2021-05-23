using UnityEngine;
using System.IO;
using System.Linq;

public class Attivazione_padine : MonoBehaviour
{
    public GameObject Mascherina;
    public GameObject Siringa;
    public GameObject Vaccino;
    public GameObject Amuchina;

    void Start()
    {
        string Login_file = Application.persistentDataPath + "/Pedina.txt"; //percorso file Pedina.txt
        var data = File.ReadAllLines(Login_file); //lettura file
        Debug.Log(data.ToArray()[0]);
        switch (data.ToArray()[0]) //impostazione pedine stato
        {
            case "Mascherina":
                {
                    Mascherina.SetActive(true);
                }
                break;

            case "Siringa":
                {
                    Siringa.SetActive(true);
                }
                break;

            case "Vaccino":
                {
                    Vaccino.SetActive(true);
                }
                break;

            case "Amuchina":
                {
                    Amuchina.SetActive(true);
                }
                break;
        }
        
    }
}
