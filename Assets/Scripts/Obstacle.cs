using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public float distanceToMove;
    public float speed;
    private float amtMoved;
    private Transform obsTransform;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start() {
        amtMoved = 0.0f;
        obsTransform = this.GetComponent<Transform>();
        startPos = new Vector3(obsTransform.position.x, obsTransform.position.y, obsTransform.position.z);
    }

    // Update is called once per frame
    void Update() {
        obsTransform.Translate(this.speed, 0.0f, 0.0f);
        amtMoved += speed;
        if (amtMoved >= distanceToMove) {
            obsTransform.position = startPos;
            amtMoved = 0.0f;
        }
    }
}
