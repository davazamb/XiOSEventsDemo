﻿using System;
using System.Linq;

namespace XiOSEventsDemo
{
	public class Validations
	{
		public enum ValidationType
		{
			User,
			Password,
			Code
		}

		public static bool ValidateInput(string text, ValidationType validationType)
		{
			var validUserChars = "abcdefghijklmnoqrstuvwxyz123456789_";
			var validPasswordChars = "abcdefghijklmnoqrstuvwxyz123456789*!$%&/()?¿!¡";
			var validCodeChars = "123456789";
			bool result = false;
			switch (validationType)
			{
				case ValidationType.User:
					result = text.ToLower().All(c => validUserChars.Contains(c));
					break;
				case ValidationType.Password:
					result = text.ToLower().All(c => validPasswordChars.Contains(c));
					break;
				case ValidationType.Code:
					result = text.ToLower().All(c => validCodeChars.Contains(c));
					break;
			}

			return result;
		}


	}
}
