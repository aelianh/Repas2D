using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
   public GameObject title;
   public GameObject mainButtons;
   public GameObject optionsMenu;

   public void OpenOptions()
   {
        title.SetActive(false);
        mainButtons.SetActive(false);
        optionsMenu.SetActive(true);
   }
}
