using System.Collections.Generic;

namespace DynamicMelt.Extensions
{
	public class Map<TKey, TValue>
	{
		public Map(IDictionary<TKey, TValue> map)
		{
			_map = map;
		}

		public TValue this[TKey key]
		{
			get
			{
				if (!_map.ContainsKey(key))
				{
					throw new KeyNotFoundException(string.Format("TableKey '{0}' not found", key));
				}

				return _map[key];
			}
		}

		private readonly IDictionary<TKey, TValue> _map;
	}
}