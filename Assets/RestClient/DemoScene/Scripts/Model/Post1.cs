using System;

namespace Models
{
	[Serializable]
	public class Post1
	{
		public int id;

		public string pes;

		public string pos;
		public int userId;


		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}

