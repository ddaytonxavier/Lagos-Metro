using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LastPlayer.LagosMetro
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        public PlayerController PlayerController;
        public AlertBox AlertBox; 

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            //PlayerController.enabled = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                instance.AlertBox.SetTitle("Do you wish to Quit?", Quit, ()=> { instance.AlertBox.gameObject.SetActive(false); });
            }
        }

        public void StartGame()
        {
            PlayerController.enabled = true;
        }

        public static void EndGame(bool isPass)
        {
            if (isPass)
            {
                instance.AlertBox.SetTitle("Demo Completed!");
            }
            else
            {
                instance.AlertBox.SetTitle("Demo Failed!");
            }
        }

        public static void NewGame()
        {
            SceneManager.LoadScene(0);
        }

        public static void Quit()
        {
            Application.Quit();
        }
    }
}