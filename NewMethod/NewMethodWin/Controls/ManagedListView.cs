using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace ManagedControls
{
	/// <summary>
	/// Summary description for ManagedListView.
	/// </summary>
	public class ManagedListView: System.Windows.Forms.ListView
	{
		private System.ComponentModel.IContainer components = null;
		
		public ManagedListView()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// we need to trap the notify message
			SetStyle(ControlStyles.EnableNotifyMessage, true);
	
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

            try
            {
                m_itemHover = null;
                m_columnClick = null;
                m_columnResize = null;
            }
            catch (System.Exception)
            { }

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


//		protected override void WndProc(ref Message m) 
//		{ 
//			switch(m.Msg) 
//			{ 
//			case WM_RBUTTONUP:
//				System.Windows.Forms.MessageBox.Show("RightClick");
//			break;
//			}
//
//			base.WndProc(ref m);
//		}

		protected override void OnNotifyMessage(Message m)
		{

//  Dim ListViewControl As ListView
//  Dim NmHdrMsg        As NMHDR
//  Dim PointStruct     As POINTAPI
//  Dim HitTestInfo     As HD_HITTESTINFO
//  Dim HeaderhWnd      As Long
//  Dim HeaderAction    As lvHeaderActions
//  Dim CancelMsg       As Boolean

			if ( m.Msg == WM_NOTIFY )
			{
				NMHDR n = (NMHDR)Marshal.PtrToStructure( m.LParam, typeof(NMHDR) );

				if( n.code == TTN_NEEDTEXT )
				{
					NeedText();
				}
					//					        Case HDN_ITEMCLICK:       HeaderAction = lvHeaderActionClick
					//        Case HDN_NM_RCLICK:       HeaderAction = lvHeaderActionRightClick

				else if( (n.code == HDN_ITEMCLICK) || (n.code == HDN_NM_RCLICK) || (n.code == UNKNOWN_CLICK) )
				{
					ColumnClickExtEventArgs ihec = new ColumnClickExtEventArgs();
					//LVHITTESTINFO lvh = new LVHITTESTINFO();

					HDHITTESTINFO lvh = new HDHITTESTINFO();
					lvh.pt = PointToClient(Control.MousePosition);
					int col = ListView_ColumnHeaderHitTest(ref lvh);

					// check if the item is valid
					if (col < 0)
					{
						return;
					}

					ihec.Column = col;
					
					if( n.code == HDN_ITEMCLICK || n.code == UNKNOWN_CLICK )
					{
						ihec.Button = System.Windows.Forms.MouseButtons.Left;
					}
					else if( n.code == HDN_NM_RCLICK )
					{
						ihec.Button = System.Windows.Forms.MouseButtons.Right;
					}
					else
					{
						return;
					}

					if( m_columnClick !=null)
					{
						m_columnClick(this, ihec);
					}
				}
				else if( n.code == HDN_ENDDRAG )
				{
					if( m_columnResize != null )
					{
						ColumnResizeEventArgs args = new ColumnResizeEventArgs();
						args.TimerOnly = true;
						m_columnResize(this, args);
					}
				}
				else if( n.code == HDN_BEGINDRAG )
				{
					//Items.Add("Begin Drag");
				}
				else if( n.code == HDN_TRACKA )
				{
					//Items.Add("Track A");
				}
				else if( n.code == HDN_TRACKW )
				{
					//Items.Add("Track W");
				}
				else if( n.code == HDN_ITEMCHANGEDW )
				{
					//Items.Add("Item Changed");
				}
				else if( n.code == UNKNOWN_DD_2 )
				{
					if( m_columnResize != null )
					{
						m_columnResize(this, new ColumnResizeEventArgs());
					}
				}

					//		private const int HDN_ENDDRAG = (HDN_FIRST-11);
					//		private const int HDN_BEGINDRAG = (HDN_FIRST-10);
					//		private const int HDN_TRACKA = (HDN_FIRST-8);
					//		private const int HDN_TRACKW = (HDN_FIRST-28);

				else
				{
					//this.Items.Add(Convert.ToString(n.code));
				}
			}

			// base.OnNotifyMessage(m);
			// calling the base class's OnNotifyMessage method is 
			// not necessary because there is no initial implementation
		}

		private void NeedText()
		{
			ItemHoverEventArgs ihea = new ItemHoverEventArgs();
			LVHITTESTINFO lvh = new LVHITTESTINFO();

			lvh.pt = PointToClient(Control.MousePosition);
			ListView_SubItemHitTest(ref lvh);

			// check if the item is valid
			if ( (lvh.iItem < 0) || 
				( lvh.iSubItem < 0 ) )
			{
				return;
			}

			ihea.Item = lvh.iItem;
			ihea.SubItem = lvh.iSubItem;
			ihea.ItemTextInVisible = IsItemTextHidden(lvh);

			if(m_itemHover!=null)
			{
				m_itemHover(this, ihea);
			}
		}

		/// <summary>
		/// Finds whether the listview item text is completely visible or 
		/// contains a trailing ellipsis "...".
		/// </summary>
		/// <param name="lvhi">List view hit test information structure</param>
		/// <returns>True if text is hidden, false otherwise</returns>
		private bool IsItemTextHidden(LVHITTESTINFO lvhi)
		{
			Rectangle rect = Rectangle.Empty;
			int stringWidth, colWidth;

			if( lvhi.iSubItem > 0 )
			{
				// MSDN : ListView_GetStringWidth() talks something about padding.
				// for subitem: The text is padded with 6 pixels on either sides

				try
				{
					stringWidth = ListView_GetStringWidth(Items[lvhi.iItem].SubItems[lvhi.iSubItem].Text);
					colWidth = ListView_GetColumnWidth(lvhi.iSubItem);
					return ((stringWidth + 12) > colWidth);
				}
				catch
				{
					return false;
				}

			}
			else
			{
				// MSDN : ListView_GetStringWidth() talks something about padding.
				// for item: The text is padded with 2 pixel on either sides

				stringWidth = ListView_GetStringWidth(Items[lvhi.iItem].Text);
				colWidth = ListView_GetColumnWidth(0);
				ListView_GetItemRect(lvhi.iItem, LVIR_LABEL, ref rect);
				rect = Rectangle.Inflate(rect, -2, -2);
				return ((rect.Left + stringWidth + 4) > colWidth);

			}

		}


		// Win API 
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
			private struct NMHDR
		{
			public IntPtr hwndFrom;
			public int idFrom;
			public int code;
		}


//		[DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
//		private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, IntPtr lParam);
//		// overloaded for wParam type
//		[DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
//		private static extern IntPtr SendMessage(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam);
//	

		[DllImport("User32.dll")] 
		static extern int SendMessage(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam); 

		[DllImport("user32.dll")]
		static extern bool SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, ref
			LV_COLUMN lParam);

		private const int WM_NOTIFY = 0x4E;

		// tooltip
		private const int TTN_FIRST = -520;
		private const int TTN_NEEDTEXT = (TTN_FIRST - 10);

		// listview
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
			private struct LVHITTESTINFO
		{
			public Point pt;
			public int flags;
			public int iItem;
			public int iSubItem;
		}

		[StructLayout(LayoutKind.Sequential)] 
			struct HDHITTESTINFO 
		{  
			public Point pt;  
			public int flags; 
			public int iItem; 
		} 

		[StructLayoutAttribute(LayoutKind.Sequential)]
			struct LV_COLUMN
		{
			public UInt32 mask;
			public Int32 fmt;
			public Int32 cx;
			public String pszText;
			public Int32 cchTextMax;
			public Int32 iSubItem;
			public Int32 iImage;
			public Int32 iOrder;
		}  

		private const int LVM_FIRST = 0x1000;
		private const int LVM_GETITEMRECT = LVM_FIRST + 14;
		private const int LVM_GETCOLUMNWIDTH = LVM_FIRST + 29;
		private const int LVM_SUBITEMHITTEST = LVM_FIRST + 57; 
		private const int LVM_GETSTRINGWIDTHW =	LVM_FIRST + 87;
		const int LVM_GETHEADER = LVM_FIRST + 31; 
		const Int32 LVM_GETCOLUMN = LVM_FIRST + 95;
		const Int32 LVM_SETCOLUMN = LVM_FIRST + 96;
		const Int32 LVCF_ORDER = 0x0020;
		
		private const int LVIR_LABEL = 2;

		private const int HHT_ONHEADER = 0x2;
        private const int HHT_ONDIVIDER = 0x4;

		const int HDM_FIRST = 0x1200; 
		const int HDM_HITTEST = HDM_FIRST + 6; 

		private const int HDN_FIRST = -300;
		private const int HDN_ITEMCLICK = (HDN_FIRST - 2);
		private const int HDN_NM_RCLICK = -5;
		private const int UNKNOWN_CLICK = -322;
		private const int UNKNOWN_DD_1 = -320;
		private const int UNKNOWN_DD_2 = -327;

		private const int HDN_ENDDRAG = (HDN_FIRST-11);
		private const int HDN_BEGINDRAG = (HDN_FIRST-10);
		private const int HDN_TRACKA = (HDN_FIRST-8);
		private const int HDN_TRACKW = (HDN_FIRST-28);
		private const int HDN_ITEMCHANGEDW = (HDN_FIRST-21);
		private const int WM_RBUTTONUP = 0x0205;

		public int ListView_ColumnHeaderPosition(int col)
		{
			LV_COLUMN pcol = new LV_COLUMN();
			pcol.mask = LVCF_ORDER;
			bool ret = SendMessage(Handle, LVM_GETCOLUMN, col, ref pcol);

			return pcol.iOrder;
		}

		private int ListView_ColumnHeaderHitTest(ref HDHITTESTINFO lvhi)
		{
//			//lvhi.flags = HHT_ONHEADER;
//
//			IntPtr ptr = Marshal.AllocHGlobal( Marshal.SizeOf(lvhi) );
//			Marshal.StructureToPtr(lvhi, ptr, true);
//								//HHT_ONHEADER Or HHT_ONDIVIDER
//			int col = SendMessage(Handle, HDM_HITTEST, IntPtr.Zero, ptr);
//				
//			HDHITTESTINFO x;
//	
//			x = (HDHITTESTINFO)Marshal.PtrToStructure(ptr, typeof(HDHITTESTINFO));
//			Marshal.FreeHGlobal(ptr);


			IntPtr hHeader = (IntPtr)SendMessage(Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero); 

			HDHITTESTINFO hitInfo = new HDHITTESTINFO(); 
			hitInfo.pt.X = lvhi.pt.X;
			hitInfo.pt.Y = lvhi.pt.Y;
			IntPtr buffer = Marshal.AllocHGlobal(Marshal.SizeOf(hitInfo)); 
			Marshal.StructureToPtr(hitInfo, buffer, true); 
			//SendMessage(this.Handle, HDM_HITTEST, IntPtr.Zero, buffer); 
			SendMessage(hHeader, HDM_HITTEST, IntPtr.Zero, buffer); 
			hitInfo = (HDHITTESTINFO)Marshal.PtrToStructure(buffer, typeof(HDHITTESTINFO)); 
			Marshal.FreeHGlobal(buffer); 

			return hitInfo.iItem;
			
		}


		private void ListView_SubItemHitTest(ref LVHITTESTINFO lvhi)
		{
			IntPtr ptr = Marshal.AllocHGlobal( Marshal.SizeOf(lvhi) );
			Marshal.StructureToPtr(lvhi, ptr, true);
								
			SendMessage(Handle, LVM_SUBITEMHITTEST, IntPtr.Zero, ptr);
								
			lvhi = (LVHITTESTINFO)Marshal.PtrToStructure(ptr, typeof(LVHITTESTINFO));
			Marshal.FreeHGlobal(ptr);
			
		}

		private int ListView_GetColumnWidth(int iCol)
		{
			//return SendMessage(Handle, LVM_GETCOLUMNWIDTH, iCol, IntPtr.Zero);
			return 0;
		}

		private int ListView_GetStringWidth(string psz)
		{
			IntPtr ptr = Marshal.StringToHGlobalAuto(psz);
			//int ret = SendMessage(Handle, LVM_GETSTRINGWIDTHW, 0, ptr);
			Marshal.FreeHGlobal(ptr);

			//return ret;
			return 0;

		}

		private bool ListView_GetItemRect(int iItem, int code, ref Rectangle lpRect)
		{
			Rectangle rct = new Rectangle();
			IntPtr pRct = Marshal.AllocHGlobal(Marshal.SizeOf(rct));
			Marshal.StructureToPtr(rct, pRct, true);

			//SendMessage(Handle, LVM_GETITEMRECT, iItem, pRct);
			
			lpRect = (Rectangle)Marshal.PtrToStructure(pRct, typeof(Rectangle));
			Marshal.FreeHGlobal(pRct);

			return true;

		}

		/// <summary>
		/// Provides data about the ItemHover event.
		/// </summary>
		public class ItemHoverEventArgs : EventArgs
		{
			// ref to listview item and sub items
			protected int m_item;
			protected int m_subitem;
			protected bool m_itemTextVisible;

			/// <summary>
			/// The zero based index of a Listview item.
			/// </summary>
			public int Item
			{
				get
				{
					return m_item;
				}
				set
				{
					m_item = value;
				}

			}

			/// <summary>
			/// The 1 based index of a ListviewSubitem item.
			/// </summary>
			public int SubItem
			{
				get
				{
					return m_subitem;
				}
				set
				{
					m_subitem = value;
				}
			}

			/// <summary>
			/// The item or subitem has text which is currently 
			/// TRUE = Invisible, FALSE = Visible.
			/// </summary>
			public bool ItemTextInVisible
			{
				get
				{
					return m_itemTextVisible;
				}
				set
				{
					m_itemTextVisible = value;
				}
			}

		}

		public class ColumnResizeEventArgs : EventArgs
		{
			// ref to listview item and sub items
			protected int m_column;
			public bool TimerOnly;
		}

		public class ColumnClickExtEventArgs : EventArgs
		{
			// ref to listview item and sub items
			protected int m_column;
			protected System.Windows.Forms.MouseButtons m_button;

			/// <summary>
			/// The zero based index of a Listview item.
			/// </summary>
			public int Column
			{
				get
				{
					return m_column;
				}
				set
				{
					m_column = value;
				}

			}

			/// <summary>
			/// The 1 based index of a ListviewSubitem item.
			/// </summary>
			public System.Windows.Forms.MouseButtons Button
			{
				get
				{
					return m_button;
				}
				set
				{
					m_button = value;
				}
			}
		}		
		
		public delegate void ItemHoverEventHandler(object sender, ItemHoverEventArgs e);
		public delegate void ColumnClickExtEventHandler(object sender, ColumnClickExtEventArgs e);
		public delegate void ColumnResizeEventHandler(object sender, ColumnResizeEventArgs e);

		protected event ItemHoverEventHandler m_itemHover;
		protected event ColumnClickExtEventHandler m_columnClick;
		protected event ColumnResizeEventHandler m_columnResize;

		public event ItemHoverEventHandler ItemHover
		{
			add
			{
				m_itemHover += value;				
			}
			remove
			{
				m_itemHover -= value;
			}
		}

		public event ColumnClickExtEventHandler ColumnClickExt
		{
			add
			{
				m_columnClick += value;				
			}
			remove
			{
				m_columnClick -= value;
			}
		}

		public event ColumnResizeEventHandler ColumnResize
		{
			add
			{
				m_columnResize += value;				
			}
			remove
			{
				m_columnResize -= value;
			}
		}
	}
}
