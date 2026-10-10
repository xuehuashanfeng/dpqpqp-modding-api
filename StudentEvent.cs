using UnityEngine;

namespace DpqApi
{
    public class StudentEvent:RandomEvent
    {
        public GameControllerScript gc;
        public float hearingVolumeScale = 0.1f; // Scale for the hearing volume during the Student event
        public float eventTimer = 0f;
        public float hearingLowPassCutoff = 2600f;
        public bool studentEventActive = false; // Flag to indicate if the Student event is active
        public float studentEventRefreshTimer = 0f; // Timer for refreshing the Student event
        public const int maxStudents = 12; // Maximum number of students allowed
        public override void Initialize()
        {
            // Initialization logic for the Student event
            base.Initialize();
            name = JsonLanguage.GetKey("StudentComing_Text");
            description = JsonLanguage.GetKey("StudentComing_description");
            eventID = 2;
            gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        }

        public override void StartEvent()
        {
            // Logic to start the Student event
            studentEventActive = true;
            studentEventRefreshTimer = 0f;
            FackStudentScript[] array = Object.FindObjectsOfType<FackStudentScript>(includeInactive: true);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    continue;
                }
                AudioManagerPlus[] componentsInChildren = array[i].GetComponentsInChildren<AudioManagerPlus>(includeInactive: true);
                for (int j = 0; j < componentsInChildren.Length; j++)
                {
                    if (componentsInChildren[j] != null)
                    {
                        componentsInChildren[j].bypassHearingBlock = true;
                    }
                }
            }
            float duration = ((eventTimer > 0f) ? eventTimer : 60f);
            PlayerHearing.Block(duration, hearingVolumeScale, hearingLowPassCutoff);
            DeafenAllBaldis(duration);
        }
        private void DeafenAllBaldis(float duration)
        {
            BaldiScript[] array = Object.FindObjectsOfType<BaldiScript>();
            foreach (BaldiScript baldiScript in array)
            {
                if (baldiScript != null && baldiScript.antiHearingTime <= 0f)
                {
                    baldiScript.ActivateAntiHearing(duration);
                }
            }
        }

        public override void StopEvent()
        {
            // Logic to stop the Student event
            if (!studentEventActive)
            {
                return;
            }
            studentEventActive = false;
            PlayerHearing.Unblock();
            BaldiScript[] array = Object.FindObjectsOfType<BaldiScript>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    array[i].antiHearingTime = 0f;
                }
            }
        }
        private void UpdateStudentEvent()
        {
            if (!studentEventActive)
            {
                return;
            }
            studentEventRefreshTimer -= Time.deltaTime;
            if (!(studentEventRefreshTimer > 0f))
            {
                studentEventRefreshTimer = 0.5f;
                float num = ((eventTimer > 0f) ? eventTimer : 0f);
                PlayerHearing.KeepAlive(num);
                if (num > 0f)
                {
                    DeafenAllBaldis(num);
                }
            }
        }
    }
}