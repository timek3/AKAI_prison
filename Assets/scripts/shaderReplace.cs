using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderReplace : MonoBehaviour
{
    public Shader shader;
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<Camera>().SetReplacementShader(shader, "Standard");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
