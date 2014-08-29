// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.

#if !(UNITY_FLASH || UNITY_NACL || UNITY_METRO || UNITY_WP8)

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Network)]
	[Tooltip("Set the textures prefix which will then be prefixed to all network ViewID numbers.\n\n" +
		"This prevents old network updates from straying into a new textures from the previous textures.\n\n" +
		"This can be set to any number and then incremented with each new textures load. " +
		"This doesn't add overhead to network traffic but just diminishes the pool of network ViewID numbers a little bit.")]
	public class NetworkSetLevelPrefix : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The textures prefix which will then be prefixed to all network ViewID numbers.")]
		public FsmInt levelPrefix;
		
		public override void Reset()
		{
			levelPrefix = null;
		}

		public override void OnEnter()
		{
			if (levelPrefix.IsNone)
			{
				LogError("Network LevelPrefix not set");
				return;
			}

			Network.SetLevelPrefix(levelPrefix.Value);
			
			Finish();
		}
	}
}

#endif