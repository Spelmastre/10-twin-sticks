using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

    private Rigidbody rigidBody;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.recording)
        {
            Record();
        } else
        {
            PlayBack();
        }
        
	}

    void PlayBack()
    {
        rigidBody.isKinematic = true;
        //int frame = Time.frameCount % bufferFrames;
        int frameCount = 0;
        foreach (MyKeyFrame keyFrame in keyFrames)
        {
            if(keyFrame.frameTime > 0)
            {
                frameCount++;
            }
        }
        int frame = Time.frameCount % frameCount;
        transform.position = keyFrames[frame].framePos;
        transform.rotation = keyFrames[frame].frameRotation;
    }

    void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        //print("Writing frame " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure for storing time, rotation and position
/// </summary>
public struct MyKeyFrame 
{
    public float frameTime;
    public Vector3 framePos;
    public Quaternion frameRotation;

    public MyKeyFrame (float time, Vector3 pos, Quaternion rot)
    {
        this.frameTime = time;
        this.framePos = pos;
        this.frameRotation = rot;
    }
}
