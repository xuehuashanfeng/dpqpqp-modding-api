using System.Collections.Generic;
using UnityEngine;

namespace DpqApi
{
    public class DpqpqpRandomEvent:RandomEvent
    {
        List<GameObject> dpqpqps = new List<GameObject>();
        public override void Initialize()
        {
            base.Initialize();
            // Initialization logic for the modded random event
            name = JsonLanguage.GetKey("CloneDpqpqp_Text");
            description = JsonLanguage.GetKey("CloneDpqpqp_description");
            eventID = 1;
        }

        public override void StartEvent()
        {
            // Logic to start the modded random event
            for(int i = 0; i < 5; i++)
            {
                GameObject dpqpqp = GameObject.Find("Dpqpqp");
                dpqpqps.Add(Object.Instantiate(dpqpqp,dpqpqp.transform.position,Quaternion.identity));
                dpqpqps[i].gameObject.SetActive(true);
                dpqpqps[i].gameObject.GetComponent<NPCScript>().killPlayer = false;
                dpqpqps[i].gameObject.GetComponent<BaldiScript>().baldiSpeedScale = Random.Range(0.5f, 1f);
                dpqpqps[i].gameObject.GetComponent<BaldiScript>().DpqpqpCator = null;
            }
        }

        public override void StopEvent()
        {
            // Logic to stop the modded random event
            foreach(GameObject dpqpqp in dpqpqps)
            {
                Object.Destroy(dpqpqp);
            }
            dpqpqps.Clear();
        }
    }
}