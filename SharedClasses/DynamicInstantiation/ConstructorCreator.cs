using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace VDFramework.DynamicInstantiation
{
	/// <summary>
	/// A helper class to get the constructor (optionally with parameters) of a type dynamically
	/// </summary>
	public static class ConstructorCreator
	{
		private static readonly Dictionary<Type, Dictionary<Type[], Delegate>> constructorsPerType = new Dictionary<Type, Dictionary<Type[], Delegate>>();
		
		/// <summary>
		/// Returns the constructor with the given parameters if one exists for the given type, otherwise <see langword="default"/>
		/// </summary>
		public static TDelegate GetConstructor<TDelegate>(Type type, params Type[] parameterTypes) where TDelegate : Delegate
		{
			if (constructorsPerType.TryGetValue(type, out Dictionary<Type[], Delegate> constructors))
			{
				foreach (KeyValuePair<Type[], Delegate> pair in constructors)
				{
					if (pair.Key.SequenceEqual(parameterTypes))
					{
						return (TDelegate)pair.Value;
					}
				}
			}
			else
			{
				constructors              = new Dictionary<Type[], Delegate>();
				constructorsPerType[type] = constructors;	
			}
			
			ConstructorInfo constructorInfo = type.GetConstructor(parameterTypes);

			if (constructorInfo == null)
			{
				return default;
			}

			ParameterExpression[] parameters = parameterTypes.Select((parameterType, index) => Expression.Parameter(parameterType, $"arg{index}")).ToArray();

			TDelegate constructor = Expression.Lambda<TDelegate>
			(
				Expression.New(constructorInfo, parameters), parameters
			).Compile();
			
			constructors.Add(parameterTypes, constructor);
			return constructor;
		}
	}
}