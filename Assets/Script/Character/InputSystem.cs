using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class InputSystem : MonoBehaviour
{

    Movement moveScript;

    [System.Serializable]

    public class InputSettings
    {
        public string forwardInput = "Vertical";
        public string strafeInput = "Horizontal";
        public string sprintInput = "Sprint";
    }
    [SerializeField]
    public InputSettings input;



    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        moveScript.AnimateCharacter(Input.GetAxis(input.forwardInput), Input.GetAxis(input.strafeInput));
        moveScript.SprintCharacter(Input.GetButton(input.sprintInput));
    }
}

