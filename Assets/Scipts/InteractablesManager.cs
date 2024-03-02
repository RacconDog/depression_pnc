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

    [SerializeField] PlayableDirector timeline;

    Camera mainCamera;

    void Start() 
    {
        timeline.Play(animations[0]);
    }

    public void PlayAnim(GameObject go)
    {
        int index = interactables.IndexOf(go);
        timeline.Play(animations[index]);
    }
}