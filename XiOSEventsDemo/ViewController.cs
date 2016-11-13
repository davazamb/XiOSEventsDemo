﻿using System;
using Foundation;
using UIKit;

namespace XiOSEventsDemo
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			btnStart.AccessibilityIdentifier = "myButton";
			btnStart.TouchUpInside+= BtnStart_TouchUpInside;
			txtName.Delegate = new UITextFieldUserValidationDelegate();
			txtPassword.WeakDelegate = this;
		}

		partial void ValueChanged(UITextField sender)
		{
			if (!string.IsNullOrEmpty(txtName.Text))
				txtPassword.Enabled = true;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void BtnStart_TouchUpInside(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
			{
				txtCode.Enabled = true;
				btnStart.TouchUpInside -= BtnStart_TouchUpInside;
				btnStart.TouchUpInside += (sen, eve) => this.ShowPopup("Hola", "Alerta");
			}
			
		}

		[Export("textField:shouldChangeCharactersInRange:replacementString:")]
		public bool ShouldChangeCharacters(UITextField textField, Foundation.NSRange range, string replacementString)
		{
			return Validations.ValidateInput(replacementString, Validations.ValidationType.Password);
		}
	}
}
