using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class Utente : MonoBehaviour
{
    public InputField User;
    public InputField Password;
    public GameObject Messaggio;

    // Start is called before the first frame update
    void Start()
    {
        string Login_file = Application.persistentDataPath + "/Login.txt"; //percorso file Login

        if (!File.Exists(Login_file)) //creazione file se non esiste
        {
            Debug.Log("File delle password non trovato, ora lo creo");
            FileStream sw = File.Create(Login_file);
            sw.Close();
            Debug.Log("Creato il file delle password");
        }

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    static string Encrypt(string value) //funzione cripta
    {        
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();
            byte[] data = md5.ComputeHash(utf8.GetBytes(value));
            return Convert.ToBase64String(data);
        }
    }

    public void Login()
    {
        string[] elenco_giocatori = new string[0];
        string[] User_Lettura = new string[0];
        string[] Password_Lettura = new string[0];
        string Login_file = Application.persistentDataPath + "/Login.txt"; //percorso file Login
        int Errori = 0;

        
        if (File.Exists(Login_file))
        {
            Debug.Log("File Found");
            //using (StreamWriter sw = File.CreateText(Login_file)) ;
            //FileStream sw = new FileStream(Login_file);
            StreamReader sw = new StreamReader(Login_file);
            var data = File.ReadAllLines(Login_file); //memorizzo in data tutti le righe
            
            
            Debug.Log(data);

            Array.Resize(ref elenco_giocatori, elenco_giocatori.Length + data.ToArray().Length);
            Array.Resize(ref User_Lettura, User_Lettura.Length + data.ToArray().Length);
            Array.Resize(ref Password_Lettura, Password_Lettura.Length + data.ToArray().Length);


            for (int i = 0; i < data.ToArray().Length; i++)
            {
                elenco_giocatori[i] = data.ToArray()[i];
                Debug.Log(data.ToArray()[i]);
                string[] subs = elenco_giocatori[i].Split(',');
                User_Lettura[i] = $"{subs[0]}";
                Password_Lettura[i] = $"{subs[1]}";

                if (User_Lettura[i] == User.text && Password_Lettura[i] == Encrypt(Password.text)) //caso esntrata
                {
                    Debug.Log("Ok sei entrato");
                    SceneManager.LoadScene(5);
                    Messaggio.SetActive(false);
                }
                else if (User_Lettura[i] != User.text || Password_Lettura[i] != Password.text) //caso errore
                {
                    Errori++;
                }
            }
            sw.Close();
            if (Errori == elenco_giocatori.Length) //mostro messaggio errore
            {
                Debug.Log("Utente e pass sono sbagliati");
                Messaggio.SetActive(true);
                Password.text = "";
            }
        }
        else //creazione file se non esiste
        {
            Debug.Log("File non trovato, ora lo creo");
            FileStream sw = File.Create(Login_file);
            sw.Close();
            Debug.Log("Creato il file delle password");
        }
    }
    
    public void Register()
    {
        string Login_file = Application.persistentDataPath + "/Login.txt"; //percorso file Login

        if (File.Exists(Login_file))
        {
            StreamWriter sw = new StreamWriter(Login_file, true);
            sw.WriteLine(User.text + "," + Encrypt(Password.text));
            sw.Close();
            SceneManager.LoadScene(5);
        }
        else //creazione file se non esiste
        {
            Debug.Log("File non trovato, ora lo creo");
            FileStream sw = File.Create(Login_file);
            sw.Close();
            Debug.Log("Creato il file delle password");
        }
    }

    /*public void pulisci()
    {
        if (Messaggio.active == true)
        {
            User.text = "";
            Messaggio.SetActive(false);
        }
    }*/

    public void Reset_Password()
    {

    }
}
