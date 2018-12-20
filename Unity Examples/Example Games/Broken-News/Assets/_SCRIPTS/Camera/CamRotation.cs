using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    Transform character;

    bool skipFrames = false;

    void Start()
    {
        character = this.transform.parent.gameObject.transform;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            mouseLook += smoothV;

            mouseLook.y = Mathf.Clamp(mouseLook.y, -80f, -5f);

        }
        else
        {

            if (Cursor.lockState != CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void lookAtTarget(Transform target)
    {
        character.LookAt(target.position, Vector3.up);
        transform.localRotation = Quaternion.Euler(character.eulerAngles.x, 0, 0);
        character.localRotation = Quaternion.Euler(0, character.eulerAngles.y, 0);
        mouseLook.Set(transform.eulerAngles.y, -transform.eulerAngles.x);

    }
    void FixedUpdate()
    {
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(mouseLook.x, character.up);
        
    }
}
