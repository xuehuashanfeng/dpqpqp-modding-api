// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// RandomEventManager
using System.Collections.Generic;
using DpqApi;
using TMPro;
using UnityEngine;

namespace DpqApi.Patch
{


	public class ModdedRandomEventManager : MonoBehaviour
	{
		public GameControllerScript gcs;
		public List<RandomEvent> randomEvents = new List<RandomEvent>();
		public bool isRandomEvent;
		public float watingTime;
		public float timer;
		public float eventTimer;
		public AudioSource audioSource;
		public AudioClip mus_randomEvent;

		public CanvasGroup timerTextCanvasGroup;

		//public EventProfiles[] eventProfiles;
		public RandomEvent thisEvent;
		public TMP_Text text;

		public bool inEvent
		{
			get
			{
				if (eventTimer > 0f)
				{
					return true;
				}

				return false;
			}
		}

		private void Start()
		{
			if (randomEvents.Count != 0)
			{
				thisEvent = randomEvents[0];
			}

			StopEvent();
		}

		private void Update()
		{
			if (isRandomEvent)
			{
				if (timer >= watingTime)//time out and start a new event
				{
					StartEvent();
				}
				else
				{
					timer += Time.deltaTime;//if not timeout counting time
				}

				if (eventTimer > 0f)
				{
					eventTimer -= Time.deltaTime;//counting down the event time
					if (eventTimer <= 0f)
					{
						StopEvent();
					}
				}
			}

			if (inEvent)
			{
				UpdateText();
				if (timerTextCanvasGroup.alpha < 1f)//i dont know what is it doing
				{
					timerTextCanvasGroup.alpha =
						Mathf.Min(1f, timerTextCanvasGroup.alpha + Time.unscaledDeltaTime * 9f);
				}
			}
			else if (timerTextCanvasGroup.alpha > 0f)
			{
				timerTextCanvasGroup.alpha -= Time.unscaledDeltaTime * 9f;
			}
		}

		public void StartEvent()
		{
			if (randomEvents.Count == 0)
			{
				return;
			}

			thisEvent = randomEvents[Random.Range(0, randomEvents.Count)];
			int eventID = thisEvent.eventID;
			audioSource.PlayOneShot(mus_randomEvent);
			eventTimer = ((thisEvent.duration > 0f) ? thisEvent.duration : Random.Range(60f, 120f));
			timer = 0f - eventTimer;
			Debug.Log("Event Manager:" + randomEvents[eventID].name);
			thisEvent.StartEvent();//start the event
		}

		public void StopEvent()
		{
			if (thisEvent == null)
			{
				watingTime = Random.Range(100f, 120f);
				return;
			}

			int eventID = thisEvent.eventID;
			watingTime = Random.Range(100f, 120f);
			thisEvent.StopEvent();//stop the event
		}

		public void OnDisable()
		{
			randomEvents[thisEvent.eventID].StopEvent();
		}

		public void SkipEvent()
		{
			thisEvent = null;
			eventTimer = 0f;
			timer = 0f;
			watingTime = Random.Range(30f, 60f);
			if (text != null)
			{
				text.text = string.Empty;
			}
		}

		public void UpdateText()
		{
			if (!(thisEvent == null) && !(text == null))
			{
				text.text = JsonLanguage.GetKey(thisEvent.name) + "\n<size=16>" + JsonLanguage.GetKey("Time_Left") +
				            Mathf.CeilToInt(eventTimer) + "\n<size=10>" + JsonLanguage.GetKey(thisEvent.description) +
				            "</size>";
			}
		}
	}
}