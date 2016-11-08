using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MovieTexture))]

/// <summary>
/// Background movie controller at the 1st scene in the game.
/// Author: Yuyang He
/// </summary>
public class BackgroundMovieControl : MonoBehaviour {

	public MovieTexture movieTexture;
	private Renderer render;

	public void Awake()
	{
		movieTexture.loop = true;
		render = GetComponent<Renderer> ();
	}
	
	// Use this for initialization
	public void Start () {
		render.material.mainTexture = movieTexture;
		movieTexture.Play ();
	}
}
