using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public RawImage Target;
    public AudioSource AudSrc;
    public RenderTexture[] CameraMovement;
    public AudioClip[] AudioClips;
    private int counter;

    private void Start()
    {
        Target.texture = CameraMovement[0];
        AudSrc.clip = AudioClips[0];
        counter = 0;
    }

    public void OnClick()
    {
        counter++;
        if (counter < 4)
        {
            Target.texture = CameraMovement[counter];
            AudSrc.clip = AudioClips[counter];
            AudSrc.Play();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
