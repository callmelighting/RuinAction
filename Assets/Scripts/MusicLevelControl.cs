using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevelControl : MonoBehaviour
{
    public AudioClip Injure;
    public AudioClip Collect;
    public AudioClip Btn1;
    public AudioClip Alter;
    public AudioClip Fire;
    public AudioClip EnemyDead;
    public AudioClip Dead;
    public AudioClip Defence;
    public AudioClip Victory;
    public AudioClip Perfectblue;

    public static float mVolume;

    public static MusicLevelControl aaa;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("levelVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("levelVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("levelVolume", 1);
            AudioListener.volume = PlayerPrefs.GetFloat("levelVolume");
        }

        aaa = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void InjureMusicPlay(bool isPlay, Vector3 position)
    {
        if (isPlay)
            AudioSource.PlayClipAtPoint(aaa.Injure, position);
        else
            ;
    }

    public static void CollectMusicPlay(bool isPlay, Vector3 position)
    {
        if (isPlay)
            AudioSource.PlayClipAtPoint(aaa.Collect, position);
        else
            ;
    }

    public static void Btn1MusicPlay(bool isPlay, Vector3 position)
    {
        if (isPlay)
            AudioSource.PlayClipAtPoint(aaa.Btn1, position);
        else
            ;
    }

    public static void AlterMusicPlay(bool isPlay, Vector3 position)
    {
        if (isPlay)
            AudioSource.PlayClipAtPoint(aaa.Alter, position);
        else
            ;
    }

    public static void FireMusicPlay(bool isPlay, Vector3 position)
    {
        if (isPlay)
            AudioSource.PlayClipAtPoint(aaa.Fire, position);
        else
            ;
    }
    public static void EnemyDeadMusicPlay(bool isPlay, Vector3 position)
    {
        if (isPlay)
            AudioSource.PlayClipAtPoint(aaa.EnemyDead, position);
        else
            ;
    }

    public static void DeadMusicPlay(bool isPlay, Vector3 position)
    {
        if (isPlay)
            AudioSource.PlayClipAtPoint(aaa.Dead, position);
        else
            ;
    }

    public static void DefenceMusicPlay(bool isPlay, Vector3 position)
    {
        if (isPlay)
            AudioSource.PlayClipAtPoint(aaa.Defence, position);
        else
            ;
    }

    public static void VictoryMusicPlay(bool isPlay, Vector3 position)
    {
        if (isPlay)
            AudioSource.PlayClipAtPoint(aaa.Victory, position);
        else
            ;
    }

    public static void PerfectblueMusicPlay(bool isPlay, Vector3 position)
    {
        if (isPlay)
            AudioSource.PlayClipAtPoint(aaa.Perfectblue, position);
        else
            ;
    }
}
