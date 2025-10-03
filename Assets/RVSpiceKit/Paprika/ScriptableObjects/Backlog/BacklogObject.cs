// zlib/libpng License
//
// Copyright (c) 2025 RabitBox
//
// This software is provided 'as-is', without any express or implied warranty.
// In no event will the authors be held liable for any damages arising from the use of this software.
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it freely,
// subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software.
//    If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
// 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
// 3. This notice may not be removed or altered from any source distribution.
using System.Collections.Generic;
using UnityEngine;

namespace RV.SpiceKit.Paprika
{
	[CreateAssetMenu(fileName = "Runtime_Backlog", menuName = "Paprika/Scriptable Objects/Backlog")]
	public partial class BacklogObject : ScriptableObject
	{
		/// <summary>
		/// バックログデータ
		/// </summary>
		private Queue<BacklogEntry> _backlogEntries = new Queue<BacklogEntry>();
		public Queue<BacklogEntry> BacklogEntries => _backlogEntries;

		/// <summary>
		/// バックログの上限
		/// </summary>
		[SerializeField] private int _limit = 50;

		/// <summary>
		/// ログ追加
		/// </summary>
		/// <param name="entry"></param>
		public void Enqueue(BacklogEntry entry)
		{
			if (_backlogEntries.Count >= _limit)
			{
				_backlogEntries.Dequeue();
			}
			_backlogEntries.Enqueue(entry);
		}

		/// <summary>
		/// ログリセット
		/// </summary>
		public void Clear() => _backlogEntries.Clear();

		/// <summary>
		/// ログの記録上限変更
		/// </summary>
		/// <param name="num"></param>
		public void ChangeLimit(int newLimit)
		{
			_limit = newLimit;

			// 上限が減った場合はシュリンクする
			while (_backlogEntries.Count >= _limit)
			{
				_backlogEntries.Dequeue();
			}
		}
	}
}
