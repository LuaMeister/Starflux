
namespace StarfluxEngine;

public class Rotator : Component, IUpdatable
{
	#region Public Field

	public float RotationSpeed { get; set; } = 1;

	#endregion

	#region Framework Methods

	public void Update()
	{
		GameObject.Transform.Rotation += RotationSpeed * Time.DeltaTime;
	}
	
	#endregion
}