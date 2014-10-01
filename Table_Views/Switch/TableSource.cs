using System;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Sample
{
    public class TableSource : UITableViewSource 
    {
		readonly Model _model;

        public TableSource(Model source)
        {
            _model = source;
        }

        public override int NumberOfSections(UITableView tableView)
        {
            return 1;
        }	

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var value = _model[indexPath.Row];
			var cell = tableView.DequeueReusableCell (MyCell.CellIdentifier) as MyCell;

			if (cell == null)
			{
				cell = new MyCell();

				cell.Switch.ValueChanged += (object sender, EventArgs e) =>
				{
					var mySwitch = sender as UISwitch;
					var currentData = _model[mySwitch.Tag];

					if (currentData.Selected)
					{
						currentData.Selected = false;
					}
					else
					{
						_model.ResetSelected();
						currentData.Selected = true;
					}

					mySwitch.SetState(currentData.Selected, true);

					tableView.ReloadData ();
				};
			} 

			cell.Switch.Tag = indexPath.Row;
			cell.Switch.SetState(value.Selected, true);

            cell.TextLabel.Text = value.Name;

            return cell;
        }
			
        public override int RowsInSection(UITableView tableview, int section)
        {
            return _model.Count;
        }

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.CellAt(indexPath);
			cell.Selected = false;
		}
    }

	class MyCell : UITableViewCell
	{
		public readonly UISwitch Switch = new UISwitch();

		public static string CellIdentifier
		{ 
			get { return "Cell"; }
		}

		public MyCell () : base (UITableViewCellStyle.Default, CellIdentifier)
		{
			AccessoryView = Switch;
		}
	}
}

