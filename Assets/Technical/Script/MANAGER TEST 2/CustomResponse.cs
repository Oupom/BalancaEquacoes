using System;

namespace Models1
{
	[Serializable]
	public class CustomResponse
	{
		public string id;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}

