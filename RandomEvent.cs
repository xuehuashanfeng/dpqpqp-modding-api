using DpqApi.Patch;
using UnityEngine;

namespace DpqApi
{
    public abstract class RandomEvent
    {
        public string name;
        public string description;
        public int eventID;
        public float duration =60f;
        public ModdedRandomEventManager rem;
        public virtual void Initialize()
        {
            // Default initialization logic
            rem = GameObject.Find("RandomEventManager").GetComponent<ModdedRandomEventManager>();
            rem.randomEvents.Add(this);
        }
        public abstract void StartEvent();
        public abstract void StopEvent();
    }
}