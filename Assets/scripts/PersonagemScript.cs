using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemScript : MonoBehaviour {


	Vector3 novaPosicao;

	void Start () {
		//posição inicial personagem
		novaPosicao = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		//touch ou clique do mouse

		if (Input.GetButton ("Fire1")) {

			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {

				novaPosicao = hit.point;
				transform.position = novaPosicao;
			}


		}

		
	}
}
