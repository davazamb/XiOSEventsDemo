using System;

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
	}
}
