using UnityEngine;
using System.Collections;

public class ParticleLayering : MonoBehaviour
{
    public string sortLayerString = "";

	void Start () {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = sortLayerString;    
	}
}
