using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public bool canReSize = true;
    public AudioSource audio;
    float scale = 0.5f;
    float audioTime;
    float beatTempo; // д╛хо180
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = gameObject.GetComponentInParent<EditScroller>().beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (canReSize)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.y <= audio.clip.length * beatTempo + 3)
            {
                transform.position += new Vector3(0, 1 * scale, 0);
                audioTime = audio.time + scale / beatTempo;
                audio.time = audioTime;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.position.y >= 3)
            {
                transform.position -= new Vector3(0, 1 * scale, 0);
                audioTime = audio.time - scale / beatTempo;
                audio.time = audioTime;
            }

        }
    }
}
