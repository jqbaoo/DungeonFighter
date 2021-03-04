using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour
{
    public string followTagName;
    private GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(followTagName);
    }

    void Update()
    {
        if (target)
        {
            this.transform.position = target.transform.position;
        }
    }
}
