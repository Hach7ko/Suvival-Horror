using UnityEngine;
using System.Collections;

public class CameraEffect : MonoBehaviour {

	public Camera[] view;
	private NoiseEffect[] noise;
	private MotionBlur[] blur;
	public Transform target;

	public int distanceMin = 10;
	private float grainSize = 0.5f;
	private float grainIntensity = 0.5f;
	private float scratchIntensity = 0.2f;

	// Use this for initialization
	void Start () {
		noise = new NoiseEffect[view.Length];
		blur = new MotionBlur[view.Length];
		for(int i = 0; i < view.Length; i++){
			noise[i] = view[i].GetComponent<NoiseEffect>();
			blur[i] = view[i].GetComponent<MotionBlur>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(target.position, transform.position);
		SetNoise(dist);
	}
	public void SetNoise(float dist)
	{
		if(dist < distanceMin)
		{
			grainIntensity = 8 - dist;
			grainSize = 5 - (dist/2);
			scratchIntensity = 8 - dist;
			for(int i = 0; i < view.Length; i++){
				blur[i].blurAmount = 1.0f - (dist/10);
			}
		}
		else
		{
			grainSize = 0.5f;
			grainIntensity = 0.5f;
			scratchIntensity = 0.2f;
			for(int i = 0; i < view.Length; i++){
				blur[i].blurAmount = 0.1f;
			}
		}
		for(int i = 0; i < view.Length; i++){
			noise[i].grainSize = grainSize;
			noise[i].grainIntensityMin = grainIntensity;
			noise[i].scratchIntensityMin = scratchIntensity;
		}
	}
}
