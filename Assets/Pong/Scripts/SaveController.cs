using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{

    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    private static SaveController _instance;

    public string namePlayer;
    public string nameEnemy;

    public string SaveWinnerKey = "SavedWinner";
 
    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
               
                _instance = FindObjectOfType<SaveController>();


                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }
               


    private void Awake()
    {
        // Garanta que apenas uma instância do Singleton exista
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
   
        // Mantenha o Singleton vivo entre as cenas
       DontDestroyOnLoad(this.gameObject);
    }

    
    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }
  
    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(SaveWinnerKey, winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(SaveWinnerKey);
    }

 public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
