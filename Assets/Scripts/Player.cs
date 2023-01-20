using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float xVel;
    private float yVel;
    private bool wDown;
    private bool aDown;
    private bool sDown;
    private bool dDown;
    public float jetPower;
    public Canvas gameOver;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start() {
        xVel = 0.0f;
        yVel = 0.0f;
        gameOver.enabled = false;
        playerTransform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        wDown = Input.GetKey(KeyCode.W);
        aDown = Input.GetKey(KeyCode.A);
        sDown = Input.GetKey(KeyCode.S);
        dDown = Input.GetKey(KeyCode.D);

        if (wDown) {
            if (!sDown) {
                yVel += (0.00001f * jetPower);
            }
        } else if (sDown) {
            yVel -= (0.00001f * jetPower);
        }
        if (aDown) {
            if (!dDown) {
                xVel -= (0.00001f * jetPower);
            }
        } else if (dDown) {
            xVel += (0.00001f * jetPower);
        }

        playerTransform.Translate(Vector3.up * yVel);
        playerTransform.Translate(Vector3.right * xVel);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Obstacle") {
            gameOver.enabled = true;
            GameObject.Destroy(this);
        } else {
            xVel = 0.0f;
            yVel = 0.0f;
        }
    }
}
