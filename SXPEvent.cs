using UnityEngine;

namespace DpqApi
{
    public class SXPEvent:RandomEvent
    {
        public GameObject SXP_DE;
        public override void Initialize()
        {
            // Initialization logic for the SXP event
            base.Initialize();
            name = JsonLanguage.GetKey("SXP-DE_Text");
            description = JsonLanguage.GetKey("SXP-DE_description");
            eventID = 0;
            SXP_DE = GameObject.Find("SXP-DE");
        }

        public override void StartEvent()
        {
            // Logic to start the SXP event
            SXP_DE.SetActive(true);
            
        }

        public override void StopEvent()
        {
            // Logic to stop the SXP event
            SXP_DE.GetComponent<NPCScript>().killPlayer = false;
            SXP_DE.SetActive(false);
        }
    }
}