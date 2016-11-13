﻿using System;
using UIKit;

namespace XiOSEventsDemo
{
	public class UITextFieldUserValidationDelegate: UITextFieldDelegate
	{
		public override bool ShouldChangeCharacters(UITextField textField, Foundation.NSRange range, string replacementString)
		{
			return Validations.ValidateInput(replacementString, Validations.ValidationType.User);
		}
	}
}
