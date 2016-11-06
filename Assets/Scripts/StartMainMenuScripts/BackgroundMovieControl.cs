using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MovieTexture))]

public class BackgroundMovieControl : MonoBehaviour {

	public MovieTexture movieTexture;
	private Renderer render;

	public void Awake()
	{
		movieTexture.loop = true;
		render = GetComponent<Renderer> ();
	}
	
	// Use this for initialization
	void Start () {
		render.material.mainTexture = movieTexture;
		movieTexture.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
