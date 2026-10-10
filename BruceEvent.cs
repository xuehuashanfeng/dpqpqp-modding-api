using UnityEngine;

namespace DpqApi
{
    public class BruceEvent:RandomEvent
    {
        public GameObject bruce;
        public override void Initialize()
        {
            // Initialization logic for the Bruce event
            name = JsonLanguage.GetKey("BruceSwap_Text");
            description = JsonLanguage.GetKey("BruceSwap_description");
            eventID = 3;
            bruce = GameObject.Find("Bruce");
            base.Initialize();
        }

        public override void StartEvent()
        {
            // Logic to start the Bruce event
            BruceScript bs = bruce.GetComponent<BruceScript>();
            bs.StartEvent();
        }

        public override void StopEvent()
        {
            // Logic to stop the Bruce event
            BruceScript bs = bruce.GetComponent<BruceScript>();
            bs.StopEvent();
        }
    }
}