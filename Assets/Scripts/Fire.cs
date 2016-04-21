using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
		public float minIntensity = 3f;
		public float maxIntensity = 5f;

		float random;

		void Start()
		{
			random = Random.Range(0.0f, 65535.0f);
		}

		void Update()
		{
			float noise = Mathf.PerlinNoise(random, Time.time);
			GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
		}
	}