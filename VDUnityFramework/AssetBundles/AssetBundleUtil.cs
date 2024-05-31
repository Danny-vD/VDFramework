using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace VDFramework.AssetBundles
{
	/// <summary>
	/// Utility class that helps with the loading and unloading of <see cref="AssetBundle"/>s and the assets therein
	/// </summary>
	public static class AssetBundleUtil
	{
		private static readonly string assemblyDirectory;

		private static readonly Dictionary<string, AssetBundle> loadedAssetBundles = new Dictionary<string, AssetBundle>();

		static AssetBundleUtil()
		{
			// TODO: Verify that this is the correct path | Maybe add extra functions that take in a path to the bundle
			assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		}

		/// <summary>
		/// <para>Attempts to load the asset with the given name in the given bundle</para>
		/// <para>It will load the bundle fisrt if it was not already loaded</para>
		/// </summary>
		/// <param name="bundleName">The name of the bundle to load the asset from</param>
		/// <param name="assetPath">The relative path of the asset within the bundle</param>
		/// <param name="asset">The asset that was loaded</param>
		/// <typeparam name="TAssetType">The type of the asset to load</typeparam>
		/// <returns>Whether the asset succesfully loaded</returns>
		public static bool TryLoadAsset<TAssetType>(string bundleName, string assetPath, out TAssetType asset) where TAssetType : Object
		{
			if (!TryGetLoadedAssetBundle(bundleName, out AssetBundle assetBundle))
			{
				asset = default;
				return false;
			}

			asset = assetBundle.LoadAsset<TAssetType>(assetPath);
			return true;
		}
		
		/// <summary>
		/// <para>Attempts to load all assets of a given type in the given bundle</para>
		/// <para>It will load the bundle first if it was not already loaded</para>
		/// </summary>
		/// <param name="bundleName">The name of the bundle to load the assets from</param>
		/// <param name="assets">An array of assets that were loaded</param>
		/// <typeparam name="TAssetType">The type of the assets to load</typeparam>
		/// <returns>Whether at least 1 asset succesfully loaded</returns>
		public static bool TryLoadAllAssets<TAssetType>(string bundleName, out TAssetType[] assets) where TAssetType : Object
		{
			if (!TryGetLoadedAssetBundle(bundleName, out AssetBundle assetBundle))
			{
				assets = default;
				return false;
			}

			assets = assetBundle.LoadAllAssets<TAssetType>();

			return assets.Length > 0;
		}

		/// <summary>
		/// Attempts to load the <see cref="AssetBundle"/>
		/// </summary>
		/// <param name="bundleName">The name of the bundle to load</param>
		/// <param name="assetBundle">The <see cref="AssetBundle"/> that was loaded</param>
		/// <returns>Whether the bundle succesfully loaded</returns>
		public static bool TryLoadAssetBundle(string bundleName, out AssetBundle assetBundle)
		{
			assetBundle = AssetBundle.LoadFromFile(GetPath(bundleName));

			if (ReferenceEquals(assetBundle, null))
			{
				return false;
			}

			loadedAssetBundles.Add(bundleName, assetBundle);
			return true;
		}
		
		/// <summary>
		/// <para>Attempts to unload the <see cref="AssetBundle"/></para>
		/// <para>This will fail if the bundle was not loaded</para>
		/// </summary>
		/// <param name="bundleName">The name of the bundle to unload</param>
		/// <param name="unloadAllLoadedObjects">Should the already loaded assets from this bundle also be unloaded?</param>
		/// <returns>Whether the bundle succesfully unloaded</returns>
		public static bool TryUnloadAssetBundle(string bundleName, bool unloadAllLoadedObjects)
		{
			if (loadedAssetBundles.Remove(bundleName, out AssetBundle bundle))
			{
				bundle.Unload(unloadAllLoadedObjects);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Unloads all loaded <see cref="AssetBundle"/>s
		/// </summary>
		/// <param name="unloadAllLoadedObjects">Should the already loaded assets from this bundle also be unloaded?</param>
		public static void UnloadAllAssetBundles(bool unloadAllLoadedObjects)
		{
			AssetBundle.UnloadAllAssetBundles(unloadAllLoadedObjects);
		}

		private static bool TryGetLoadedAssetBundle(string bundleName, out AssetBundle assetBundle)
		{
			if (loadedAssetBundles.TryGetValue(bundleName, out AssetBundle bundle))
			{
				assetBundle = bundle;
				return true;
			}

			return TryLoadAssetBundle(bundleName, out assetBundle);
		}

		private static string GetPath(string path)
		{
			return Path.Combine(assemblyDirectory, path);
		}
	}
}