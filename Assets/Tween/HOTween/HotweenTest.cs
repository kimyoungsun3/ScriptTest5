using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

namespace Tween_HOTWeen
{
	public class HotweenTest : MonoBehaviour
	{
		public Transform tnCube1;
		public Transform tnCube2;
		public Transform tnCube3;


		//public UISlider uiSlider;
		//public UIScrollBar uiScrollBar;
		//public UIProgressBar uiProgressBar;

		[Header("cube2")]
		[SerializeField] Vector3 deltaPos2;
		[SerializeField] Vector3 deltaAngle2;
		[SerializeField] LoopType loopType2;
		[SerializeField] EaseType easeType2;

		[Header("cube3")]
		[SerializeField] Vector3 deltaPos3;
		[SerializeField] Vector3 deltaAngle3;
		[SerializeField] LoopType loopType3;
		[SerializeField] EaseType easeType3;
		[SerializeField] Color color3 = Color.red;
		void Start()
		{
			HOTween.Init(true, true, true);

			//----------------------------------------------------
			HOTween.To(tnCube1, 4, "position", tnCube1.position + Vector3.up * 5);
			//HOTween.To(tnCube1, 4, "rotation", tnCube1.rotation * Quaternion.Euler(0, 360+1, 0));
			HOTween.To(tnCube1, 4, "eulerAngles", new Vector3(0, 360*4, 0));
			HOTween.To(tnCube1.GetComponent<MeshRenderer>().material, 4, "color", new Color(1f, 0, 0));

			//--------------------------------------------------------
			//HOTween.To(tnCube2, 4, new TweenParms()
			//	.Prop("position", tnCube2.position + Vector3.up * 5, false)
			//	.Prop("eulerAngles", new Vector3(0, 360 * 4, 0), false)
			//	.Loops(-1, LoopType.Yoyo)
			//	.Ease(EaseType.EaseInOutQuad)
			//	.OnStepComplete(OnStepComplete)
			//	.OnComplete(OnComplete)
			//	.OnUpdate(OnUpdate)
			//	);

			//HOTween.To(tnCube2, 4, new TweenParms()
			//	.Prop("position", deltaPos2, true)
			//	.Prop("eulerAngles", deltaAngle2, true)
			//	.Loops(-1, loopType2)
			//	.Ease(easeType2)
			//	.OnStepComplete(OnStepComplete)
			//	.OnComplete(OnComplete)
			//	.OnUpdate(OnUpdate)
			//	);
			HOTween.To(tnCube2, 4, new TweenParms()
				.Prop("localPosition", deltaPos2, true)
				.Prop("localEulerAngles", deltaAngle2, true)
				.Loops(-1, loopType2)
				.Ease(easeType2)
				.OnStepComplete(OnStepComplete)
				.OnComplete(OnComplete)
				.OnUpdate(OnUpdate)
				);

			//--------------------------------------------------------
			//Material _mat3 = tnCube3.GetComponent<Renderer>().material;
			//Sequence _sequence = new Sequence(new SequenceParms().Loops(-1, LoopType.Yoyo));
			////_sequence.AppendInterval(.1f);
			//_sequence.Append(HOTween.To(tnCube3, 1, new TweenParms().Prop("localEulerAngles", new Vector3(0, 360, 0), true)));
			//_sequence.Append(HOTween.To(tnCube3, 1, new TweenParms().Prop("localPosition", new Vector3(0, 5, 0), true)));
			//_sequence.Append(HOTween.To(tnCube3, 1, new TweenParms().Prop("localEulerAngles", new Vector3(0, 360, 0), true)));
			//Debug.Log(_sequence.duration);
			//float _time = _sequence.duration * 0.5f;
			//_sequence.Insert(_time, HOTween.To(_mat3, _time, new TweenParms().Prop("color", color3)));
			//_sequence.Play();

			//Material _mat3 = tnCube3.GetComponent<Renderer>().material;
			//Sequence _seq = new Sequence(new SequenceParms().Loops(-1, loopType3));
			//_seq.Append(HOTween.To(tnCube3, 1f, new TweenParms().Prop("localEulerAngles", deltaAngle3, true)));
			//_seq.Append(HOTween.To(tnCube3, 1f, new TweenParms().Prop("localPosition", deltaPos3, true)));
			//_seq.Append(HOTween.To(tnCube3, 1f, new TweenParms().Prop("localEulerAngles", deltaAngle3, true)));
			//float _duration = _seq.duration * 0.3f;
			//_seq.Insert(_duration, HOTween.To(_mat3, _duration, new TweenParms().Prop("color", color3)));
			//_seq.Play();

			//Material _mat3 = tnCube3.GetComponent<Renderer>().material;
			//Sequence _seq = new Sequence(new SequenceParms().Loops(-1, loopType3));
			//_seq.Append(HOTween.To(tnCube3, 1f, new TweenParms().Prop("localEulerAngles", deltaAngle3, true)));
			//_seq.Append(HOTween.To(tnCube3, 1f, new TweenParms().Prop("localPosition", deltaPos3, true)));
			//_seq.Append(HOTween.To(tnCube3, 1f, new TweenParms().Prop("localEulerAngles", deltaAngle3, true)));
			//float _duration = _seq.duration * 0.3f;
			//_seq.Insert(_duration, HOTween.To(_mat3, _duration, new TweenParms().Prop("color", color3)));
			//_seq.Play();

			Material _mat3 = tnCube3.GetComponent<Renderer>().material;
			Sequence _seq = new Sequence(new SequenceParms().Loops(-1, loopType3));
			_seq.Append(HOTween.To(tnCube3, 1f, new TweenParms().Prop("localEulerAngles", deltaAngle3, true)));
			_seq.Append(HOTween.To(tnCube3, 1f, new TweenParms().Prop("localPosition", deltaPos3, true)));
			_seq.Append(HOTween.To(tnCube3, 1f, new TweenParms().Prop("localEulerAngles", deltaAngle3, true)));
			_seq.Insert(1f, HOTween.To(_mat3, 1f, new TweenParms().Prop("color", color3)));
			_seq.Play();
		}

		void OnStepComplete(){Debug.Log(this + " >> OnStepComplete");}
		void OnComplete(){	Debug.Log(this + " >> OnComplete");	}
		void OnUpdate()	{	Debug.Log(this + " >> OnUpdate");	}

		private void OnChange()
		{
			//Debug.Log();
		}

	}
}
