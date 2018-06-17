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

        void Start() {
            // Get Time remaining for game, subtract standard reaction time, and multiply by its buttonpressespersecond
            PagesNeeded = Mathf.FloorToInt((MicrogameTimer.instance.beatsLeft * StageController.beatLength - ReactionTime) 
                * ButtonPressesPerSecond);
    
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PagesRead++;
            }   
        }
    }

}