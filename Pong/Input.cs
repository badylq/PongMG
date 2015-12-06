using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
	class Input
	{
		private Dictionary<PlayerInput, Keys> keyBinds;  
		public Input()
		{
			keyBinds = new Dictionary<PlayerInput, Keys>();
		}

		public bool IsPressing(PlayerInput pInput)
		{
			if (keyBinds.ContainsKey(pInput) && Keyboard.GetState().IsKeyDown(keyBinds[pInput]))
			{
				return true;
			}
			return false;
		}

		public void BindKey(Keys key, PlayerInput action)
		{
			if (keyBinds.ContainsKey(action))
			{
				keyBinds[action] = key;
			}
			else
			{
				keyBinds.Add(action,key);
			}
		}
	}

	public enum PlayerInput
	{
		Left,
		Right,
		Start,
	}
}
