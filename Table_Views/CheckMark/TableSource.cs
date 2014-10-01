using MonoTouch.UIKit;

namespace Sample
{
    public class TableSource : UITableViewSource 
    {
        readonly static string cellIdentifier = "Cell";
        readonly Model _model;

        public TableSource(Model source)
        {
            _model = source;
        }

        public override int NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {
            var value = _model[indexPath.Row];

			var cell = tableView.DequeueReusableCell (cellIdentifier) ??
			                    new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);

            cell.TextLabel.Text = value.Name;

            cell.Accessory = value.Selected ?
				UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;

            return cell;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return _model.Count;
        }
            
        public override void RowSelected(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {
            var cell = tableView.CellAt(indexPath);
            var data = _model[indexPath.Row];

            if (data.Selected)
            {
                data.Selected = false;
                cell.Accessory = UITableViewCellAccessory.None;
            }
            else
            {
				_model.ResetSelected ();

                data.Selected = true;
                cell.Accessory = UITableViewCellAccessory.Checkmark;
            }

            cell.Selected = false;

			tableView.ReloadData ();
        }
    }
}

