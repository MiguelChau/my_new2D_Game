using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using UnityEngine.SceneManagement;

namespace Screens
{

    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;

        public ScreenType startScreen = ScreenType.PANEL;

        private ScreenBase _currentScreen;


        private void Start()
        {
            HideAll();
            ShowByType(startScreen);
        }
        public void ShowByType(ScreenType type)
        {
            if (_currentScreen != null) _currentScreen.Hide();

            var nextScreen = screenBases.Find(i => i.screenType == type);

            if (nextScreen != null)
            {
                nextScreen.Show();
                _currentScreen = nextScreen;

                if (type == ScreenType.PLAY) 
                {
                    SceneManager.LoadScene(1); 
                }
            }  
            
        }

        public void HideAll()
        {
            screenBases.ForEach(i => i.Hide());
        }

    }

}
