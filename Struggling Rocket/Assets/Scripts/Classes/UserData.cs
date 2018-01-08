using UnityEngine;

[System.Serializable]
public class UserData {
	public string nickName;
	public float distanceTraveled;

	public bool IsGreaterThan(UserData other)
	{
		return distanceTraveled > other.distanceTraveled;
	}
}