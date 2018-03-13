using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemScript : MonoBehaviour {

	public GameObject personagem;
	public float velocidade;
	Vector3 novaPosicao;
	Animation ani;

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "item") {
			Destroy (c.gameObject);
		}
	}

	void Start () {
		//posição inicial personagem
		novaPosicao = transform.position;
		ani = personagem.GetComponent<Animation> ();
		//define a animação inicial do personagem
		ani.CrossFade ("idle");
		
	}
	
	// Update is called once per frame
	void Update () {
		//touch ou clique do mouse

		if (Input.GetButton ("Fire1")) {

			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit) && (hit.collider.gameObject.tag != "Player") ) {
				novaPosicao = hit.point;
				//transform.position = novaPosicao;
				transform.position = Vector3.MoveTowards (transform.position, novaPosicao, velocidade * Time.deltaTime);
				ani.CrossFade ("run");			

				transform.LookAt (hit.point);

			} else {
				ani.CrossFade ("idle");
			}


		}
		
	}
}
