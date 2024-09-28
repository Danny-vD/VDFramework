using System;
using System.Collections.Generic;
using System.Linq;
using VDFramework.LootTables.Interfaces;
using VDFramework.LootTables.Structs;
using VDFramework.RandomWrapper;
using VDFramework.RandomWrapper.Interface;

namespace VDFramework.AliasMethod
{
	/// <summary>
	/// Provides an implementation of a Alias table for the purposes of sampling discrete distributions.
	/// </summary>
	/// <theory>
	/// https://research.nvidia.com/labs/rtr/publication/wyman2021alias/
	/// </theory>
	public class AliasTable<TType>
	{
		/// <summary>
		/// The combined weight of every sample in the table.
		/// </summary>
		public long TotalWeight { get; private set; }

		/// <summary>
		/// The average weight per sample in the table.
		/// </summary>
		public double AverageWeight { get; private set; }

		/// <summary>
		/// Whether or not the table is empty.
		/// </summary>
		public bool IsValid => aliasTable != null && aliasTable.Length != 0;

		private AliasTableEntry<TType>[] aliasTable;

		/// <summary>
		/// A constructor that immediately constructs the alias table using the given collection.
		/// </summary>
		public AliasTable(IEnumerable<LootTablePair<TType>> sortedCollection)
		{
			Construct(sortedCollection);
		}

		/// <summary>
		/// The default constructor that does not immediately construct a table.
		/// </summary>
		/// <seealso cref="Construct"/>
		public AliasTable()
		{
		}

		/// <summary>
		/// Construct an alias table from the given pairs of {<see cref="ILoot{TLootType}"/>, Weight}
		/// </summary>
		/// <param name="sortedCollection">A collection of {<see cref="ILoot{TLootType}"/>, Weight} pairs</param>
		public void Construct(IEnumerable<LootTablePair<TType>> sortedCollection)
		{
			LinkedList<LootTablePair<TType>> linkedList = new LinkedList<LootTablePair<TType>>(sortedCollection);

			int count = linkedList.Count;

			aliasTable = new AliasTableEntry<TType>[count];

			TotalWeight   = linkedList.Sum(pair => pair.Weight > 0 ? pair.Weight : 0);
			AverageWeight = TotalWeight / (double)count;

			LootTablePair<TType> highestPair = linkedList.Last();
			double highestPairWeight = highestPair.Weight;

			for (int i = 0; i < count; i++)
			{
				LootTablePair<TType> lowestPair = linkedList.First.Value;

				AliasTableEntry<TType> tableEntry = new AliasTableEntry<TType>(lowestPair.Loot, highestPair.Loot, lowestPair.Weight / AverageWeight);

				linkedList.RemoveFirst();

				highestPairWeight -= AverageWeight - lowestPair.Weight;

				if (highestPairWeight <= 0)
				{
					linkedList.RemoveLast();

					highestPair       = linkedList.Last();
					highestPairWeight = highestPair.Weight;
				}

				aliasTable[i] = tableEntry;
			}
		}

		/// <summary>
		/// Sample the alias table based on the weights and returns the result.<br/>
		/// Uses the <paramref name="rng"/> or <see cref="SystemRandom"/> if that is null
		/// </summary>
		public ILoot<TType> Sample(IRandomNumberGenerator rng)
		{
			if (!IsValid)
			{
				throw new InvalidOperationException("The table has not been constructed yet.\nBe sure to call Construct() before you try to sample it!");
			}

			rng ??= SystemRandom.StaticInstance;

			int index = rng.Next(aliasTable.Length);

			AliasTableEntry<TType> aliasTableEntry = aliasTable[index];
			double threshold = rng.GetPercentage();

			return threshold < aliasTableEntry.Threshold ? aliasTableEntry.LowerSample : aliasTableEntry.HigherSample;
		}

		/// <summary>
		/// Sample the alias table based on the weights and returns the result.<br/>
		/// Uses <see cref="System.Random">System.Random</see>
		/// </summary>
		public ILoot<TType> Sample()
		{
			return Sample(SystemRandom.StaticInstance);
		}

		/// <summary>
		/// Clears the entire alias table
		/// </summary>
		public void Clear()
		{
			aliasTable = null;
		}
	}
}