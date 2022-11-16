using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject PantallaFinal;
    public GameObject PantallaVictoria;
    public GameObject Personaje;
    public GameObject[] Vidas;
    

    // Start is called before the first frame update
    void Awake()
    {
        
        //Si ya hay una instancia y no soy yo me destruyo
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);

    }

    public void RestarVidas()
    {
        
        AudioManager.Instance.SonidoImpacto();

       
        if(Global.vidas == 1)
        {
            Vidas[0].SetActive(false);
            PantallaFinal.SetActive(true);
            Personaje.SetActive(false);
        }
        else if(Global.vidas == 2)
        {
            Vidas[1].SetActive(false);
        }
        else if(Global.vidas == 3)
        {
            Vidas[2].SetActive(false);
        }
        Global.vidas--;

    }
     public void SumarPuntos()
    {
        Global.estrellas ++;
        AudioManager.Instance.SonidoEstrella();
        if(Global.estrellas == 3)
        {
            Debug.Log("onichan o///o");
            PantallaVictoria.SetActive(true);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
