﻿// zlib/libpng License
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
using System;
using UnityEngine;

namespace RV.SpiceKit.Paprika
{
	public partial class MessageEvents : ScriptableObject
	{
		[NonSerialized] public Action<string> onChangeName;
		[NonSerialized] public Action<string> onChangeMessage;

		[SerializeField] private string _name;
		[SerializeField] private string _message;

		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				onChangeName?.Invoke(value);
			}
		}
		public string Message
		{
			get => _message;
			set
			{
				_message = value;
				onChangeMessage?.Invoke(value);
			}
		}
	}
}
