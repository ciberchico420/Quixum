﻿using System;
using System.Collections;
using System.Collections.Generic;
using Colyseus.Schema;
using UnityEngine;
using UnityEngine.EventSystems;

public class GolfBall2:MonoBehaviour, ConnectedObject
{
    public AudioSource audioSource { get;set;}
    public ObjectState state;

    private AudioClip collitionSound;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Client.Instance.addReadyListener(init);
        collitionSound = Resources.Load<AudioClip>("Sounds/BallCollition");
        audioSource =gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 0.88f;
       // audioSource.clip = collitionSound;
    }

    public void play(AudioClip clip, float volume)
    {
        
        audioSource.PlayOneShot(clip,volume);
    }
    public void setState(ObjectState ob){
        this.state = ob;
       // if(Client.Instance.golfballs.)
       if( !Client.Instance.golfballs.ContainsKey(ob.owner)){
           Client.Instance.golfballs.Add(ob.owner,GetComponent<SObject>());
       }else{
           Debug.Log("GolfBall was aready added");
       }
        
    }

    // Start is called before the first frame update

    void init(){
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMessage(ObjectMessage m)
    {
        //throw new NotImplementedException();
    }

    public void sendMessageToRoom(string m)
    {
        //throw new NotImplementedException();
    }
}
