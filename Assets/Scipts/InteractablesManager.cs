using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InteractablesManager : MonoBehaviour
{
    public List<GameObject> interactables;
    [SerializeField] private List<PlayableAsset> animations;

    [SerializeField] private PlayableDirector dogAnim;
    [SerializeField] GameObject book;
    [SerializeField] GameObject closeText;
    [SerializeField] PlayableDirector timeline;

    bool isTextOpen = false;

    public bool isSidequest;
    private Camera mainCamera;
    [SerializeField] public int gameIndex = 1;

    public void PlayAnim(GameObject go)
    {
        int index = interactables.IndexOf(go);
        
        if (isSidequest != true)
        {
            if (index == gameIndex)
            {
                timeline.Play(animations[index]);
                gameIndex += 1;
            }
        }
        else if (go == book)
        {
            if (isTextOpen == false)
            {
                timeline.Play(animations[0]);
            }
        }
        else
        {
            timeline.Play(animations[0]);
        }


        if (go == dogAnim.gameObject)
        {
            dogAnim.enabled = false;
        }

        if (go == book)
        {
            closeText.SetActive(true);
            isTextOpen = true;
        }

        if (go == closeText)
        {
            closeText.SetActive(false);
            isTextOpen = false;
        }
    }
}