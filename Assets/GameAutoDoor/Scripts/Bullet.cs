using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameShoot
{
	public class Bullet : MonoBehaviour
	{

		[SerializeField] LayerMask mask;
		[SerializeField] float speed = 5f;

		[SerializeField] Transform bulletBody;
		[SerializeField] float bodyTurnSpeed = 720f;
		[SerializeField] ParticleSystem bombEffect;

		// Update is called once per frame
		void Update()
		{
			float _distance = speed * Time.deltaTime;
			Ray _ray = new Ray(transform.position, transform.forward);
			RaycastHit _hit;

			if (Physics.Raycast(_ray, out _hit, _distance + 0.05f, mask, QueryTriggerInteraction.Ignore))
			{
				ParticleSystem _ps = Instantiate(bombEffect, _hit.point, Quaternion.LookRotation(_hit.normal)) as ParticleSystem;
				_ps.Stop();
				_ps.Play();
				Destroy(_ps.gameObject, _ps.main.duration);

				//CameraController.ins.Shake();

				player.ClearAction(this);
				DestroyImmediate(gameObject);
				return;
			}

			transform.Translate(Vector3.forward * _distance);
			bulletBody.Rotate(Vector3.forward * bodyTurnSpeed * Time.deltaTime);
			//Debug.DrawRay(transform.position, transform.forward * _distance);
		}

		Player player;
		public void SetData(Player _player)
		{
			player = _player;
		}

		public void OnThisClear()
		{
			Destroy(gameObject);
		}
	}
}