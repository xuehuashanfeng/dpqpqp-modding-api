using UnityEngine;

namespace DpqApi.Creation
{
    public static class ObjectCreator
    {
        public static SoundKeyCode CreateSoundKeyCode(Color color,AudioClip clip,string name,bool useCustomTime,string subtitle,float? time)
        {
            SoundKeyCode soundKeyCode = ScriptableObject.CreateInstance<SoundKeyCode>();
            soundKeyCode.color = color;
            soundKeyCode.audioClip = clip;
            soundKeyCode.name = name;
            soundKeyCode.contents.Add(subtitle);
            if(useCustomTime) 
            {
                soundKeyCode.useCustomTime = true;
                soundKeyCode.durations.Add(time ?? 0f);
            } else
            {
                soundKeyCode.useCustomTime = false;
            }
            return soundKeyCode;
        }

        public static EventProfiles CreateEventProfiles(string name, string description,int id)
        {
            EventProfiles eventProfiles = ScriptableObject.CreateInstance<EventProfiles>();
            eventProfiles.name = name;
            eventProfiles.description = description;
            eventProfiles.eventID = id;
            return eventProfiles;
        }
        public static StyleProfiles CreateStyleProfiles(string name, string text,int notebooks,int maxExits,bool fog,Color color,Sprite sprite,MusicProfiles musicProfiles)
        {
            StyleProfiles styleProfiles = ScriptableObject.CreateInstance<StyleProfiles>();
            styleProfiles.styleName = name;
            styleProfiles.notebooks = notebooks;
            styleProfiles.maxExits = maxExits;
            styleProfiles.welcomeText = text;
            styleProfiles.fog = fog;
            styleProfiles.fogColor = color;
            styleProfiles.schoolMusic = musicProfiles;
            styleProfiles.pauseImage = sprite;
            return styleProfiles;
        }
        public static MusicProfiles CreateMusicProfiles(string name, float bpm,string author,AudioClip musicClip)
        {
            MusicProfiles musicProfiles = ScriptableObject.CreateInstance<MusicProfiles>();
            musicProfiles.musicName = name;
            musicProfiles.BPM = bpm;
            //not support midi
            musicProfiles.AudioClipMusic = musicClip;
            musicProfiles.author = author;
            return musicProfiles;
        }
    }
}