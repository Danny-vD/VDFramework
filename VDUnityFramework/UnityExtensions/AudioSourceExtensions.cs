using System.Collections.Generic;
using UnityEngine;

namespace VDUnityFramework.UnityExtensions
{
	public static class AudioSourceExtensions
	{
		public static AudioSource GetFirstNotPlaying(this List<AudioSource> list)
		{
			if (list.Count == 0)
			{
				return null;
			}

			for (int i = 0; i < list.Count; ++i)
			{
				AudioSource audioSource = list[i];

				if (audioSource.isPlaying)
				{
					continue;
				}

				return audioSource;
			}

			return null;
		}
	}
}
