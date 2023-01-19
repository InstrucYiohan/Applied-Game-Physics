using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace lagarde
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private bool hasStarted = false;
        [SerializeField] private TextMeshProUGUI startStopTxt;

        private void Start()
        {
            Time.timeScale = 0;
            startStopTxt.text = "START";
        }

        public void StartStop()
        {
            hasStarted = !hasStarted;

            if (hasStarted)
            {
                startStopTxt.text = "STOP";
                Time.timeScale = 10;
            }
            else if (!hasStarted)
            {
                startStopTxt.text = "START";
                Time.timeScale = 0;
            }
        }

        public void Reset()
        {
            Time.timeScale = 0;
            startStopTxt.text = "START";
            hasStarted = false;

            Star[] allStars = GameObject.FindObjectsOfType<Star>();
            foreach (Star str in allStars)
            {
                str.Reset();
            }

            StarPanel[] panels = GameObject.FindObjectsOfType<StarPanel>();
            foreach (StarPanel p in panels)
            {
                p.DefaultsOnUI();
            }

            CameraMovement cam = GameObject.FindObjectOfType<CameraMovement>();
            cam.Reset();
        }

    }

}
