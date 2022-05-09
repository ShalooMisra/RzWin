using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DraggableTabControl
{
    public delegate void TabMoveHandler(TabPage p);

	[ToolboxBitmap(typeof(DraggableTabControl))]
	/// <summary>
	/// Summary description for DraggableTabPage.
	/// </summary>
	public class DraggableTabControl : System.Windows.Forms.TabControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private bool MouseDownIs = false;
        private Point MousePoint;
        public event TabMoveHandler zz_TabMoved;

		public DraggableTabControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			AllowDrop = true;

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion

		protected override void OnDragOver(System.Windows.Forms.DragEventArgs e)
		{
            MouseDownIs = false;
			base.OnDragOver(e);
		
			Point pt = new Point(e.X, e.Y);
			//We need client coordinates.
			pt = PointToClient(pt);
			
			//Get the tab we are hovering over.
			TabPage hover_tab = GetTabPageByTab(pt);

			//Make sure we are on a tab.
			if(hover_tab != null)
			{
				//Make sure there is a TabPage being dragged.
                if (e.Data.GetDataPresent(typeof(DraggableTabHandle)))
				{
					e.Effect = DragDropEffects.Move;
                    DraggableTabHandle h = (DraggableTabHandle)e.Data.GetData(typeof(DraggableTabHandle));
                    TabPage drag_tab = h.page;

					int item_drag_index = FindIndex(drag_tab);
					int drop_location_index = FindIndex(hover_tab);

                    if (item_drag_index == 0 || drop_location_index == 0)
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }

					//Don't do anything if we are hovering over ourself.
                    if (item_drag_index != drop_location_index)
                    {
                        this.SuspendLayout();

                        ArrayList pages = new ArrayList();

                        //Put all tab pages into an array.
                        for (int i = 0; i < TabPages.Count; i++)
                        {
                            //Except the one we are dragging.
                            if (i != item_drag_index)
                                pages.Add(TabPages[i]);
                        }

                        //Now put the one we are dragging it at the proper location.
                        pages.Insert(drop_location_index, drag_tab);

                        //Make them all go away for a nanosec.
                        TabPages.Clear();

                        //Add them all back in.
                        TabPages.AddRange((TabPage[])pages.ToArray(typeof(TabPage)));

                        //Make sure the drag tab is selected.
                        SelectedTab = drag_tab;

                        //TabPage selTabPage = TabPages[item_drag_index];
                        //TabPage repTabPage = TabPages[drop_location_index];
                        //TabPages[drop_location_index] = selTabPage;
                        //TabPages[item_drag_index] = repTabPage;
                        //SelectedTab = selTabPage;

                        this.ResumeLayout();

                        if (zz_TabMoved != null)
                            zz_TabMoved(TabPages[item_drag_index]);
					}
				}
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
            MouseDownIs = true;
            MousePoint = new Point(e.X, e.Y);
		}

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MouseDownIs = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (MouseDownIs && MousePoint != new Point(e.X, e.Y))
            {
                Point pt = new Point(e.X, e.Y);
                TabPage tp = GetTabPageByTab(pt);

                if (tp != null)
                {
                    DoDragDrop(new DraggableTabHandle(tp), DragDropEffects.All);
                }
            }
        }

		/// <summary>
		/// Finds the TabPage whose tab is contains the given point.
		/// </summary>
		/// <param name="pt">The point (given in client coordinates) to look for a TabPage.</param>
		/// <returns>The TabPage whose tab is at the given point (null if there isn't one).</returns>
		private TabPage GetTabPageByTab(Point pt)
		{
			TabPage tp = null;

			for(int i = 0; i < TabPages.Count; i++)
			{
				if(GetTabRect(i).Contains(pt))
				{
					tp = TabPages[i];
					break;
				}
			}
			
			return tp;
		}

		/// <summary>
		/// Loops over all the TabPages to find the index of the given TabPage.
		/// </summary>
		/// <param name="page">The TabPage we want the index for.</param>
		/// <returns>The index of the given TabPage(-1 if it isn't found.)</returns>
		private int FindIndex(TabPage page)
		{
			for(int i = 0; i < TabPages.Count; i++)
			{
				if(TabPages[i] == page)
					return i;
			}

			return -1;
		}
	}

    public class DraggableTabHandle
    {
        public TabPage page;
        public DraggableTabHandle(TabPage p)
        {
            page = p;
        }
    }
}
