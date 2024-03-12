using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Playables;

public class InteractablesManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> interactables;
    [SerializeField] private List<PlayableAsset> animations;

    [SerializeField] private PlayableDirector dogAnim;
    [SerializeField] PlayableDirector timeline;

    Camera mainCamera;
    [SerializeField] int gameIndex = 1;

    void Start() 
    {
        timeline.Play(animations[0]);
    }

    public void PlayAnim(GameObject go)
    {
        int index = interactables.IndexOf(go);
        
        if (index == gameIndex)
        {
            timeline.Play(animations[index]);
            gameIndex += 1;
        }
        if (go == dogAnim.gameObject)
        {
            dogAnim.enabled = false;
        }
    }
}