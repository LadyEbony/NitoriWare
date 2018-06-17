using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NitorInc.KosuzuRead {
    public class KosuzuReadController : MonoBehaviour {

        [Header("Button Press Requirements")]
        [SerializeField] private int PagesNeeded;
        [SerializeField] private int PagesRead = 0;

        [Header("Difficulty parameters")]
        [SerializeField] private float ButtonPressesPerSecond = 2.0f;
        [SerializeField] private float ReactionTime = 0.4f;

        [Header("Debug Tools")]
        [SerializeField] private TextMesh PagesTextMesh;

        void Start() {
            Debug.Log(MicrogameTimer.instance.beatsLeft + " | " + StageController.beatLength + " | " + Time.timeScale);

            // Get Time remaining for game (scaled as well)
            // Subtract standard reaction time
            // And multiply by the required button presses
            PagesNeeded = Mathf.FloorToInt((MicrogameTimer.instance.beatsLeft * StageController.beatLength / Time.timeScale - ReactionTime) 
                * ButtonPressesPerSecond);

            UpdateTextMeshDebug();
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PagesRead++;
                UpdateTextMeshDebug();
            }   
        }

        void UpdateTextMeshDebug()
        {
            PagesTextMesh.text = (PagesNeeded - PagesRead).ToString();
        }
    }

}