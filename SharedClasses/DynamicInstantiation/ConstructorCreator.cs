using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace VDFramework.DynamicInstantiation
{
	public static class ConstructorCreator
	{
		public static Dictionary<Type, Dictionary<Type[], Delegate>> constructorsPerType = new Dictionary<Type, Dictionary<Type[], Delegate>>();
		
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

			constructors              = new Dictionary<Type[], Delegate>();
			constructorsPerType[type] = constructors;
			
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