// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.UIKit;

namespace Sample
{
	public partial class TableViewController : UITableViewController
	{
		public TableViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.TableView.Source = new TableSource(Model.Init());
        }
	}
}
