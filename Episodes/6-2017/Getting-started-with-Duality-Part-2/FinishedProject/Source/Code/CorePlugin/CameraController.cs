using System;
using System.Collections.Generic;
using System.Linq;

using Duality;
using Duality.Components;
using Duality.Components.Physics;
using Duality.Input;
using Duality.Editor;

namespace DotGame
{
	[RequiredComponent(typeof(Camera))]
	public class CameraController : Component, ICmpUpdatable
	{
		private Transform followTarget = null;
		private float smoothness = 1.0f;

		public Transform FollowTarget
		{
			get { return this.followTarget; }
			set { this.followTarget = value; }
		}
		public float Smoothness
		{
			get { return this.smoothness; }
			set { this.smoothness = value; }
		}

		void ICmpUpdatable.OnUpdate()
		{
			Transform transform = this.GameObj.Transform;
			Camera camera = this.GameObj.GetComponent<Camera>();

			Vector3 targetPos = this.followTarget.Pos - new Vector3(0.0f, 0.0f, camera.FocusDist);
			Vector3 currentPos = transform.Pos;
			Vector3 posDiff = (targetPos - currentPos);
			Vector3 targetVelocity = posDiff * MathF.Pow(2.0f, -this.smoothness);

			transform.MoveByAbs(targetVelocity * Time.TimeMult);
		}
	}
}
