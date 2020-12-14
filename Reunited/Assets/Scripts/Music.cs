using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    //DontDestroyOnLoad for music
    //Also checks current level, if past a certain level, stops looping current music. Once this music stops playing,
    //starts playing the next version of music.
    static Music instance;

    public AudioSource title;
    public AudioSource theme1;
    public AudioSource theme2;
    public AudioSource theme3;

    private int prevLevel;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
        title.Play();

        //Sets previous level to determine how music will transition. Ex: from title to first level vs from lvl 5 - lvl 6.
        prevLevel = 0;
    }

    private void OnLevelWasLoaded(int level)
    {
        //switch statement that determines which clip should be used.
        switch (level)
        {
            case 0:
                //On title page / level select
                if (!title.isPlaying)
                {
                    title.Play();
                    theme1.Stop();
                    theme2.Stop();
                    theme3.Stop();
                }
                break;
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                //Uses first theme
                if (!theme1.isPlaying)
                {
                    title.Stop();
                    theme1.Play();
                    theme2.Stop();
                    theme3.Stop();
                }
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                //Uses second theme
                if (!theme2.isPlaying)
                {
                    title.Stop();
                    theme1.Stop();
                    theme2.Play();
                    theme3.Stop();
                }
                break;
            case 11:
            case 12:
            case 13:
                //Uses third theme
                if (!theme3.isPlaying)
                {
                    title.Stop();
                    theme1.Stop();
                    theme2.Stop();
                    theme3.Play();
                }
                break;
        }
    }
}
