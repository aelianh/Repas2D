using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject PantallaFinal;
    public GameObject Personaje;


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
        Global.vidas--;
        AudioManager.Instance.SonidoImpacto();
        if(Global.vidas == 0)
        {
            Debug.Log("onichan uwu");
            PantallaFinal.SetActive(true);
            Personaje.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
